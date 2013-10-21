using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;
using HERBProject.DB.Infrastructure.MapFactories.MapDomainToConceptualModel;

namespace HERBProject.DB.Infrastructure.Repositories
{
    public class RepositoryBase<TInput, TOutput> : IDisposable
        where TInput : class
        where TOutput : EntityObject
    {
        protected ObjectContext _context;

        protected IEnumerable<TOutput> Find(string query, System.Data.Objects.ObjectParameter parameters)
        {
            return _context.CreateQuery<TOutput>(query, parameters).AsEnumerable<TOutput>();
        }

        protected TOutput Find(TInput entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity to be created can not be null");
            }

            MapDomainToConceptualModelFactoryBase factory = SwitcherEntityToRepositoryFactory.GetFactoryFor(typeof(TInput), typeof(TOutput));
            var mapped = factory.GetDbObjectFromEntity<TInput, TOutput>(entity);

            string entityName = GetEntitySetName(mapped.GetType());
            System.Data.EntityKey key = _context.CreateEntityKey(entityName, mapped);

            return _context.GetObjectByKey(key) as TOutput;
        }

        protected TOutput Create(TInput entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity to be created can not be null");
            }

            MapDomainToConceptualModelFactoryBase factory = SwitcherEntityToRepositoryFactory.GetFactoryFor(typeof(TInput), typeof(TOutput));
            var mapped = factory.GetDbObjectFromEntity<TInput, TOutput>(entity);

            string entityName = GetEntitySetName(mapped.GetType());

            _context.AddObject(entityName, mapped);

            return mapped;
        }

        protected IEnumerable<TOutput> CreateCollection(IEnumerable<TInput> entities)
        {
            if (entities == null || entities.Count() == 0)
            {
                throw new ArgumentNullException("Entity to be created can not be null");
            }

            MapDomainToConceptualModelFactoryBase factory = SwitcherEntityToRepositoryFactory.GetFactoryFor(typeof(TInput), typeof(TOutput));
            IEnumerable<TOutput> mappedIEnumerable = factory.GetDbObjectsFromEntities<TInput, TOutput>(entities);

            string entityName = GetEntitySetName(mappedIEnumerable.First().GetType());

            mappedIEnumerable.ToList().ForEach(entity => _context.AddObject(entityName, mappedIEnumerable));

            return mappedIEnumerable;
        }

        protected TOutput Delete(TInput entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity to be created can not be null");
            }

            MapDomainToConceptualModelFactoryBase factory = SwitcherEntityToRepositoryFactory.GetFactoryFor(typeof(TInput), typeof(TOutput));
            var mapped = factory.GetDbObjectFromEntity<TInput, TOutput>(entity);

            mapped = GetOrAttachDbObject(mapped);

            _context.DeleteObject(mapped);

            return mapped;
        }

        protected IEnumerable<TOutput> DeleteCollection(IEnumerable<TInput> entities)
        {
            if (entities == null || entities.Count() == 0)
            {
                throw new ArgumentNullException("Entity to be created can not be null");
            }

            MapDomainToConceptualModelFactoryBase factory = SwitcherEntityToRepositoryFactory.GetFactoryFor(typeof(TInput), typeof(TOutput));
            IEnumerable<TOutput> mappedIEnumerable = factory.GetDbObjectsFromEntities<TInput, TOutput>(entities);

            foreach (var entity in mappedIEnumerable)
            {
                var mapped = GetOrAttachDbObject(entity);
                _context.DeleteObject(mapped);

            }

            return mappedIEnumerable;
        }

        protected virtual TOutput Update(TInput entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity to be created can not be null");
            }

            MapDomainToConceptualModelFactoryBase factory = SwitcherEntityToRepositoryFactory.GetFactoryFor(typeof(TInput), typeof(TOutput));
            var mapped = factory.GetDbObjectFromEntity<TInput, TOutput>(entity);

            string entityName = GetEntitySetName(mapped.GetType());
            System.Data.EntityKey key = _context.CreateEntityKey(entityName, mapped);
            object originalItem;

            if (_context.TryGetObjectByKey(key, out originalItem))
            {
                _context.ApplyPropertyChanges(key.EntitySetName, mapped);
            }

            return mapped;

        }

        protected virtual IEnumerable<TOutput> UpdateCollection(IEnumerable<TInput> entities)
        {
            if (entities == null || entities.Count() == 0)
            {
                throw new ArgumentNullException("Entity to be created can not be null");
            }

            MapDomainToConceptualModelFactoryBase factory = SwitcherEntityToRepositoryFactory.GetFactoryFor(typeof(TInput), typeof(TOutput));
            IEnumerable<TOutput> mappedIEnumerable = factory.GetDbObjectsFromEntities<TInput, TOutput>(entities);

            string entityName = GetEntitySetName(mappedIEnumerable.First().GetType());

            foreach (var entity in mappedIEnumerable)
            {
                System.Data.EntityKey key = _context.CreateEntityKey(entityName, entity);
                object originalItem;

                if (_context.TryGetObjectByKey(key, out originalItem))
                {
                    _context.ApplyPropertyChanges(key.EntitySetName, entity);
                }
            }

            return mappedIEnumerable;
        }

        protected int Persist(object entityOrCollection)
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (OptimisticConcurrencyException)
            {
                _context.Refresh(System.Data.Objects.RefreshMode.ClientWins, entityOrCollection);
                return _context.SaveChanges();
            }
        }

        protected virtual void Rollback(object entityOrCollection)
        {
            if (entityOrCollection == null)
            {
                throw new ArgumentNullException("Entity to be created can not be null");
            }

            if (entityOrCollection.GetType() == typeof(IEnumerable<object>).GetGenericTypeDefinition())
            {
                List<TOutput> mapped = new List<TOutput>();

                foreach (var entity in entityOrCollection as IEnumerable<object>)
                {
                    MapDomainToConceptualModelFactoryBase factory = SwitcherEntityToRepositoryFactory.GetFactoryFor(typeof(TInput), typeof(TOutput));
                    var mappedItem = factory.GetDbObjectFromEntity<TInput, TOutput>(entity as TInput);
                    mappedItem = GetOrAttachDbObject(mappedItem);
                    mapped.Add(mappedItem);
                    _context.Refresh(System.Data.Objects.RefreshMode.StoreWins, mapped);
                }
            }
            else
            {
                MapDomainToConceptualModelFactoryBase factory = SwitcherEntityToRepositoryFactory.GetFactoryFor(typeof(TInput), typeof(TOutput));
                var mapped = factory.GetDbObjectFromEntity<TInput, TOutput>(entityOrCollection as TInput);
                mapped = GetOrAttachDbObject(mapped);
                _context.Refresh(System.Data.Objects.RefreshMode.StoreWins, mapped);
            }

        }

        protected System.Data.Objects.ObjectQuery<TOutput> CreateQuery(bool withTracking)
        {
            string entityName = GetEntitySetName();

            System.Data.Objects.ObjectQuery<TOutput> query = _context.CreateQuery<TOutput>(entityName);

            if (!withTracking) { query.MergeOption = System.Data.Objects.MergeOption.NoTracking; }

            return query;
        }

        private string GetEntitySetName()
        {
            string entityName = typeof(TOutput).Name;

            var entityContainer = _context.MetadataWorkspace.GetEntityContainer(_context.DefaultContainerName, DataSpace.CSpace);

            return entityContainer.BaseEntitySets.Where(meta => meta.ElementType.Name == entityName).Select(meta => meta.Name).FirstOrDefault();
        }

        private string GetEntitySetName(Type entityType)
        {
            string entityName = entityType.Name;

            var entityContainer = _context.MetadataWorkspace.GetEntityContainer(_context.DefaultContainerName, DataSpace.CSpace);

            return entityContainer.BaseEntitySets.Where(meta => meta.ElementType.Name == entityName).Select(meta => meta.Name).FirstOrDefault();
        }

        private TOutput GetOrAttachDbObject(TOutput mapped)
        {
            ObjectStateEntry entry;
            string entityName = GetEntitySetName(mapped.GetType());
            System.Data.EntityKey key = _context.CreateEntityKey(entityName, mapped);
            mapped.EntityKey = key;

            if (!_context.ObjectStateManager.TryGetObjectStateEntry(key, out entry)) _context.Attach(mapped);
            else mapped = _context.GetObjectByKey(key) as TOutput;
            return mapped;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~RepositoryBase()
        {
            Dispose(false);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using System.IO;

namespace HERBProject.WebUI.Helpers
{
    public static class DIGlobalRegister
    {

        public enum EnumRegistrationType { justWithDecoratedClasses, withAllClasses };

        static private List<Type> _interfaceNamesToBeCustomRegistered = new List<Type>();

        private static void customRegistration(ContainerBuilder builder)
        {

            //_interfaceNamesToBeCustomRegistered.Add(typeof(IAircraftRepository));
            //builder.RegisterType<AircraftRepository>().As<IAircraftRepository>().SingleInstance();

            RegisterControllers(builder);

        }

        public static void RegisterWithBuilder(ContainerBuilder builder, AppDomain currentDomain, EnumRegistrationType enumRegistrationType)
        {

            List<Assembly> vuelingAssembliesList = new List<Assembly>();
            Assembly[] vuelingAssembliesArray;

            customRegistration(builder);

            List<Assembly> assemblies = System.Web.Compilation.BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList();

            foreach (var assembly in assemblies)
            {

                if (assembly.GetName().Name.ToLower().Contains("vueling")) vuelingAssembliesList.Add(Assembly.Load(assembly.GetName().Name));

            }
            vuelingAssembliesArray = vuelingAssembliesList.ToArray<Assembly>();

            if (enumRegistrationType == EnumRegistrationType.justWithDecoratedClasses) RegisterAssemblyTypesWithDecoratedClasses(builder, vuelingAssembliesArray);
            else RegisterAssemblyTypes(builder, vuelingAssembliesArray);

        }

        public static void RegisterWithBuilderFromPath(ContainerBuilder builder, AppDomain currentDomain, EnumRegistrationType enumRegistrationType)
        {

            List<Assembly> vuelingAssembliesList = new List<Assembly>();
            Assembly[] vuelingAssembliesArray;

            customRegistration(builder);

            List<Assembly> assemblies = currentDomain.GetAssemblies().ToList<Assembly>();

            var loadedAssemblies = currentDomain.GetAssemblies().ToList();
            var loadedPaths = loadedAssemblies.Select(a => a.Location).ToArray();

            var referencedPaths = Directory.GetFiles(currentDomain.BaseDirectory, "*.dll");
            var toLoad = referencedPaths.Where(r => !loadedPaths.Contains(r, StringComparer.InvariantCultureIgnoreCase)).ToList();
            toLoad.ForEach(path => loadedAssemblies.Add(currentDomain.Load(AssemblyName.GetAssemblyName(path))));

            foreach (var referencedAssembly in toLoad)
            {

                assemblies.Add(Assembly.LoadFrom(referencedAssembly));

            }

            foreach (var assembly in assemblies.Distinct())
            {

                if (assembly.GetName().Name.ToLower().Contains("vueling")) vuelingAssembliesList.Add(Assembly.Load(assembly.GetName().Name));

            }
            vuelingAssembliesArray = vuelingAssembliesList.ToArray<Assembly>();

            if (enumRegistrationType == EnumRegistrationType.justWithDecoratedClasses) RegisterAssemblyTypesWithDecoratedClasses(builder, vuelingAssembliesArray);
            else RegisterAssemblyTypes(builder, vuelingAssembliesArray);

        }

        private static void RegisterAssemblyTypesWithDecoratedClasses(ContainerBuilder builder, Assembly[] vuelingAssemblies)
        {

            //builder.RegisterAssemblyTypes(vuelingAssemblies)
            //    .Where(t => t.GetCustomAttributes(typeof(RegisterServiceAttribute), false).Any())
            //    .Where(t => !_interfaceNamesToBeCustomRegistered.Contains(t.GetInterfaces().First()))
            //    .As(t => t.GetInterfaces()[0]).AsImplementedInterfaces();

            //builder.RegisterAssemblyTypes(vuelingAssemblies)
            //    .Where(t => t.GetCustomAttributes(typeof(RegisterConfigurationAttribute), false).Any())
            //    .Where(t => !_interfaceNamesToBeCustomRegistered.Contains(t.GetInterfaces().First()))
            //    //    .As(t => t.GetInterfaces()[0]).AsImplementedInterfaces().SingleInstance(); //static registered
            //    .As(t => t.GetInterfaces()[0]).AsImplementedInterfaces();

            //builder.RegisterAssemblyTypes(vuelingAssemblies)
            //    .Where(t => t.GetCustomAttributes(typeof(RegisterContextAttribute), false).Any())
            //    .Where(t => !_interfaceNamesToBeCustomRegistered.Contains(t.GetInterfaces().First()))
            //        .As(t => t.GetInterfaces()[0]).AsImplementedInterfaces().InstancePerLifetimeScope(); //instance per request registered

        }

        private static void RegisterAssemblyTypes(ContainerBuilder builder, Assembly[] vuelingAssemblies)
        {

            var vuelingTypes = vuelingAssemblies.SelectMany(a => a.GetTypes())
                .Where(t => !t.IsInterface && !t.IsAbstract).OrderBy(t => t.Name).ToList();
            var interfacesImplements = new Dictionary<Type, Type>();


            Assembly.GetExecutingAssembly().GetTypes().Where(t => !t.IsAbstract).ToList()
                .ForEach(c => RegisterTypeDependencies(c, vuelingTypes, interfacesImplements));

            interfacesImplements.ToList().ForEach(
                delegate(KeyValuePair<Type, Type> ii)
                {

                    builder.RegisterType(ii.Value).As(ii.Key).AsImplementedInterfaces();

                });

        }

        private static void RegisterTypeDependencies(Type registerComponenttype, IEnumerable<Type> vuelingTypes, IDictionary<Type, Type> typesInterfaces)
        {
            var paramInterfaces = registerComponenttype.GetConstructors().SelectMany(
                c => c.GetParameters()).Select(p => p.ParameterType).Where(
                pt => pt.IsInterface).ToList();

            foreach (var paramInterface in paramInterfaces)
            {

                var types = vuelingTypes.Where(paramInterface.IsAssignableFrom).ToList();

                if (!types.Any())
                {
                    //Traza interface sin implementación => adicionar referencia
                    break;
                }

                if (types.Count() > 1)
                {
                    //Traza interface con más de una implementación => registro personalizado
                    break;
                }

                RegisterTypeDependencies(types[0], vuelingTypes, typesInterfaces);

                AddComponentType(paramInterface, types[0], typesInterfaces);

            }

        }

        private static void AddComponentType(Type interfaze, Type type, IDictionary<Type, Type> interfacesImplements)
        {
            if (interfacesImplements != null && interfaze != null && type != null &&
                    interfaze.IsInterface &&
                    interfaze.IsAssignableFrom(type) &&
                    !interfacesImplements.ContainsKey(interfaze) &&
                    !_interfaceNamesToBeCustomRegistered.Contains(interfaze))
            {
                interfacesImplements.Add(interfaze, type);
            }

        }

        private static void RegisterControllers(ContainerBuilder builder)
        {

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

        }

    }
}
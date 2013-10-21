using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HERBProject.Library.Entities
{
    public class ProjectEntity
    {
        #region .: Properties

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
        public string File_Project { get; set; }
        public virtual IList<UserEntity> UserEntities { get; set; }
        #endregion
    }
}

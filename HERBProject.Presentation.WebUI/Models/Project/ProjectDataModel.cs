using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HERBProject.Presentation.WebUI.Models.Project
{
    public class ProjectDataModel
    {
        #region .: Properties

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
        public string File_Project { get; set; }
        public virtual IList<User.UserDataModel> UserEntities { get; set; }
        #endregion
    }
}
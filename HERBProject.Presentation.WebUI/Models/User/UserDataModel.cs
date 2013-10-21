using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HERBProject.Presentation.WebUI.Models.User
{
    public class UserDataModel
    {
        #region .: properties

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public virtual IList<Project.ProjectDataModel> ProjectEntities { get; set; }


        #endregion        

    }
}

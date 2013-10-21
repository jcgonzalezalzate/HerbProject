using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HERBProject.Library.Entities
{
    public class UserEntity
    {


        #region .: properties

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public virtual IList<ProjectEntity> ProjectEntities { get; set; }



        #endregion      


        

    }
}

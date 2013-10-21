using System;
using System.Linq;
using System.Web;


namespace HERBProject.WebUI.Helpers
{
    public static class SecurityHelper
    {
        public static bool IsAuthorizedUser(Type type, string actionName)
        {
            var result = false;
            var roles = "";
            var typeAttributes = type.GetCustomAttributes(false);


            var actionAttributes = type.GetMethod(actionName).GetCustomAttributes(false);

            var attributes = typeAttributes == null || typeAttributes.Count() == 0 ? actionAttributes : typeAttributes;

          
            foreach (var item in roles.Split(','))
            {
                if (HttpContext.Current.User.IsInRole(item))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}
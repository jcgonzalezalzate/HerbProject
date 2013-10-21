using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Reflection;
using System.Globalization;
using Autofac;
using Autofac.Integration.Mvc;
using HERBProject.WebUI.Helpers;

namespace HERBProject.WebUI
{

    public class MvcApplication : System.Web.HttpApplication
    {
        protected string ApplicationId = "HERBProject.WebUI";


        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new LoggingFilterAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("SSO/SSO.ashx");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(./)?favicon.ico(/.)?" });
            routes.IgnoreRoute("{*allaspx}", new { allaspx = @".*\.aspx(/.*)?" });
            routes.IgnoreRoute("{*alljs}", new { alljs = @".*\.js(/.*)?" });

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_BeginRequest()
        {
            
        }

        protected void Application_Start()
        {

            try
            {    
                AreaRegistration.RegisterAllAreas();
                RegisterGlobalFilters(GlobalFilters.Filters);
                RegisterRoutes(RouteTable.Routes);

                var builder = new ContainerBuilder();
                AppDomain currentDomain = AppDomain.CurrentDomain;
                DIGlobalRegister.RegisterWithBuilder(builder, currentDomain, DIGlobalRegister.EnumRegistrationType.justWithDecoratedClasses);
                var dependencyContainer = builder.Build();
                DependencyResolver.SetResolver(new AutofacDependencyResolver(dependencyContainer));

            }
            catch (Exception anyException)
            {
                Trace.TraceError("Problem enabling, registing and resolving dependencies on Global.asax " + anyException.Message);
            }

        }

        protected void Application_Error(object sender, EventArgs e)
        {

            Exception lastException = Server.GetLastError();
            Trace.TraceError(string.Format("Unhandled error"));
            Server.ClearError();

        }
    }
}
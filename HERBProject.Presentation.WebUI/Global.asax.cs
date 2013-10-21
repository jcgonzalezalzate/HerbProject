using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;

namespace HERBProject.Presentation.WebUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);


            var builder = new ContainerBuilder();
            AppDomain currentDomain = AppDomain.CurrentDomain;
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<HERBProject.Impl.ServiceLibrary.Impl.MannageUser>().As<HERBProject.Contracts.ServiceLibrary.Contracts.IMannageUser>();
            builder.Register(c => new HERBProject.Presentation.WebUI.Controllers.User.UserController(c.Resolve<HERBProject.Contracts.ServiceLibrary.Contracts.IMannageUser>())).As<System.Web.Mvc.Controller>();
            builder.Register(c => new HERBProject.Impl.ServiceLibrary.Impl.MannageUser(c.Resolve<HERBProject.Library.InfrastructureContracts.IMannageUserLibrary>())).As<HERBProject.Contracts.ServiceLibrary.Contracts.IMannageUser>();
            builder.RegisterType<HERBProject.DB.Infrastructure.Configuration.InfrastructureConfiguration>().As<HERBProject.DB.Infrastructure.Configuration.IInfrastructureConfiguration>();
            builder.Register(c => new HERBProject.DB.Infrastructure.Imp.MannagerUser(c.Resolve<HERBProject.DB.Infrastructure.Configuration.IInfrastructureConfiguration>())).As<HERBProject.Library.InfrastructureContracts.IMannageUserLibrary>();

            //DIGlobalRegister.RegisterWithBuilder(builder, currentDomain, DIGlobalRegister.EnumRegistrationType.justWithDecoratedClasses);
            var dependencyContainer = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(dependencyContainer));
        }

        
    }
}
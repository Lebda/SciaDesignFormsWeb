using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Areas_Help.AreaSelection;
using SciaDesignFormsModel.DataContexts.SciaDesignForms;
using SciaDesignFormsWeb.Infrastructure.IoC;

namespace SciaDesignFormsWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var intializer = new SciaDesignFormsModel.Intializers.SciaDesignForms.SciaDesignFormsDbInitializer();
            System.Data.Entity.Database.SetInitializer((System.Data.Entity.IDatabaseInitializer<SciaDesignFormsDb>)intializer);

            // DOne in advance
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerSelector), new AreaHttpControllerSelector(GlobalConfiguration.Configuration));

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            NinjectResolver resolver = (NinjectResolver)GlobalConfiguration.Configuration.DependencyResolver;
            resolver.AddBindings(Ioc_Help.Infrastructure.NinjectModule.Bindings);
            resolver.AddBindings(SciaDesignFormsModel.Module.NinjectModule.Bindings);
            resolver.AddBindings(SdfCalculationService.Infrastructure.NinjectModule.Bindings);
            System.Web.Mvc.DependencyResolver.SetResolver((System.Web.Mvc.IDependencyResolver)resolver);
        }
    }
}
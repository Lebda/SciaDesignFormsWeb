using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SciaDesignFormsWeb.Infrastructure.IoC;
using Areas_Help.AreaSelection;

namespace SciaDesignFormsWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // DOne in advance
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerSelector), new AreaHttpControllerSelector(GlobalConfiguration.Configuration));

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            NinjectResolver resolver = (NinjectResolver)GlobalConfiguration.Configuration.DependencyResolver;
            resolver.AddBindings(Ioc_Help.Infrastructure.NinjectModule.Bindings);
            resolver.AddBindings(SdfCalculationService.Infrastructure.NinjectModule.Bindings);
            System.Web.Mvc.DependencyResolver.SetResolver((System.Web.Mvc.IDependencyResolver)resolver);
        }
    }
}
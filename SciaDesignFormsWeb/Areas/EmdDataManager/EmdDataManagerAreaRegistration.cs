using System.Web.Http;
using System.Web.Mvc;
using Areas_Help.AreaSelection;

namespace SciaDesignFormsWeb.Areas.EmdDataManager
{
    public class EmdDataManagerAreaRegistration : AreaRegistration 
    {
        public const string c_areaName = "EmdDataManager";
        public override string AreaName
        {
            get { return c_areaName; }
        }
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            //context.MapHttpRoute(
            //    c_areaName + "_DefaultActionApi",
            //    AreaName + "/api/{controller}/{action}/{id}",
            //    new { area = AreaName, id = RouteParameter.Optional });

            context.MapHttpRoute(
                c_areaName + "_DefaultApi",
                AreaName + "/api/{controller}/{id}",
                new { area = AreaName, id = RouteParameter.Optional });

            context.MapRoute(
                c_areaName + "_Default",
                AreaName + "/{controller}/{action}/{id}",
                new { area = AreaName, action = "Index", id = UrlParameter.Optional });
        }
    }
}
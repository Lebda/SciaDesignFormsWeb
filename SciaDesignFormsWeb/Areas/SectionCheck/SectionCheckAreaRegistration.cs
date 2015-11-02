using System.Web.Http;
using System.Web.Mvc;
using Areas_Help.AreaSelection;

namespace SciaDesignFormsWeb.Areas.SectionCheck
{
    public class SectionCheckAreaRegistration : AreaRegistration 
    {
        public const string c_areaName = "SectionCheck";
        public override string AreaName 
        {
            get { return c_areaName; }
        }
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapHttpRoute(
                c_areaName + "_DefaultNonRestApi",
                AreaName + "/api/nrest/{controller}/{action}/{ClcID}/{CombiID}/{OutPutType}",
                new { area = AreaName });

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
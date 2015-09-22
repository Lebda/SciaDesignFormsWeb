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
                "SectionCheck_DefaultNonRestApi",
                AreaName + "/api/nrest/{controller}/{action}/{ClcID}/{CombiID}/{OutPutType}",
                new { area = AreaName });

            context.MapHttpRoute(
                "SectionCheck_DefaultApi",
                AreaName + "/api/{controller}/{id}",
                new { area = AreaName, id = UrlParameter.Optional });

            context.MapRoute(
                "SectionCheck_default",
                AreaName + "/{controller}/{action}/{id}",
                new { area = AreaName, action = "Index", id = UrlParameter.Optional });
        }
    }
}
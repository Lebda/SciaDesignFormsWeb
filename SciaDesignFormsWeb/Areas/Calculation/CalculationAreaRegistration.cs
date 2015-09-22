using System.Web.Mvc;
using Areas_Help.AreaSelection;

namespace SciaDesignFormsWeb.Areas.Calculation
{
    public class CalculationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Calculation";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapHttpRoute(
                "Calculation_DefaultNonRestApi",
                AreaName + "/api/nrest/{controller}/{action}/{ClcID}/{CombiID}/{OutPutType}",
                new { area = AreaName });

            context.MapHttpRoute(
                "Calculation_DefaultApi",
                AreaName + "/api/{controller}/{id}",
                new { area = AreaName, id = UrlParameter.Optional });

            context.MapRoute(
                "Calculation_default",
                AreaName + "/{controller}/{action}/{id}",
                new { area = AreaName, action = "Index", id = UrlParameter.Optional });
        }
    }
}
using System;
using System.Linq;
using System.Web.Mvc;

namespace SciaDesignFormsWeb.Areas.SectionCheck.Controllers
{
    [Authorize]
    public class UIController : Controller
    {
        // GET: SectionCheck/UI
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult ClientIntegrationPartial()
        {
            return PartialView();
        }
    }
}
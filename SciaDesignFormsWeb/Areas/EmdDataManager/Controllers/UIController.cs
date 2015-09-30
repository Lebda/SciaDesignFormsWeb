using System;
using System.Linq;
using System.Web.Mvc;

namespace SciaDesignFormsWeb.Areas.EmdDataManager.Controllers
{
    public class UIController : Controller
    {
        // GET: EmdDataManager/UI
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
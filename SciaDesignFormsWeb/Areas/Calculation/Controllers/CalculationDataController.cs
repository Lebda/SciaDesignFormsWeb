using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using SdfCalculationService.Abstract.Calculation;
using SdfCalculationService.Abstract.HttpCalculation;

namespace SciaDesignFormsWeb.Areas.Calculation.Controllers
{
    public class CalculationDataController : ApiController
    {
        public CalculationDataController(ICalculationDataCreator creator)
        {
            m_creator = creator;
        }

        #region MEMBERS
        readonly ICalculationDataCreator m_creator;
        #endregion

        public HttpResponseMessage Get()
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            IWebApiCalculationData content = m_creator.GetWebApi();
            result.Content = new ObjectContent(content.GetType(), content, new JsonMediaTypeFormatter());
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return result;
        }
    }
}

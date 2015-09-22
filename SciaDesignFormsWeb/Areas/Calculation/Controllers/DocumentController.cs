using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using SdfCalculationService.Concrete;
using SdfCalculationService.Concrete.HttpDocument;

namespace SciaDesignFormsWeb.Areas.Calculation.Controllers
{
    public class DocumentController : ApiController
    {
        public DocumentController(IDocumentPicturesCreator creator)
        {
            m_creator = creator;
        }

        #region MEMBERS
        readonly IDocumentPicturesCreator m_creator;
        #endregion

        public HttpResponseMessage Get([FromUri]CalculationContext context)
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ObjectContent<WebApiDocument>(m_creator.GetWebApiDocument(context), new JsonMediaTypeFormatter());
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return result;
        }

        #region MEMBERS
        #endregion

    }
}

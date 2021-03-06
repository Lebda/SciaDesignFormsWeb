﻿using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using SdfCalculationService.Abstract.Document;
using SdfCalculationService.Abstract.HttpDocument;
using SdfCalculationService.Concrete.Shared;

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
            IWebApiDocument content = m_creator.GetWebApiDocument(context);
            result.Content = new ObjectContent(content.GetType(), content, new JsonMediaTypeFormatter());
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return result;
        }
    }
}

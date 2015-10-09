using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using SciaDesignFormsModel.Abstract;

namespace SciaDesignFormsWeb.Areas.EmdDataManager.Controllers
{
    public class EmdActiveStructureController : ApiController
    {
        public EmdActiveStructureController(
            IDbEmdFileRepository repoFiles,
            IDbEmdStructureRepository repoStruct)
        {
            m_repoFiles = repoFiles;
            m_repoStructs = repoStruct;
        }

        #region MEMBERS
        readonly IDbEmdFileRepository m_repoFiles;
        readonly IDbEmdStructureRepository m_repoStructs;
        #endregion

        #region METHODS
        protected override void Dispose(bool disposing)
        {
            m_repoFiles.Dispose();
            m_repoStructs.Dispose();
            base.Dispose(disposing);
        }
        #endregion

        #region INTERFACE
        public HttpResponseMessage GetEmdActiveStructure()
        {
            string userID = User.Identity.GetUserId();
            var queryFiles4User = m_repoFiles.DataQueryable().Where(item => item.ApplicationUserID == userID).ToList();
            if (queryFiles4User == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            var queryStructs = m_repoStructs.DataQueryable().Where(item => item.IsSelected).ToList();
            var query = queryStructs.Where(item => queryFiles4User.Any(file => file.ID == item.ID)).FirstOrDefault();
            if (query == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.OK, query);
        }
        #endregion
    }
}
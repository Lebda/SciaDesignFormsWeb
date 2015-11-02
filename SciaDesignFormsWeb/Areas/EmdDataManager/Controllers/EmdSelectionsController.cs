using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using SciaDesignFormsModel.Abstract.Repositories;
using SciaDesignFormsModel.ViewModels.EsaModelData;

namespace SciaDesignFormsWeb.Areas.EmdDataManager.Controllers
{
    public class EmdSelectionsController : ApiController
    {
        public EmdSelectionsController(
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
        public HttpResponseMessage GetEmdSelections()
        {
            string userID = User.Identity.GetUserId();
            var queryFiles4User = m_repoFiles.DataQueryable().Where(item => item.ApplicationUserID == userID).ToList();
            if (queryFiles4User == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            var queryStructs = m_repoStructs.DataQueryable().Where(item => item.IsSelected).ToList().Where(item => queryFiles4User.Any(file => file.ID == item.ID)).FirstOrDefault();
            DbEmdSelectionViewModel retVal = new DbEmdSelectionViewModel();
            if (queryStructs == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, retVal);
            }
            retVal.ActiveStructure = queryStructs.CreateViewModel(m_repoFiles.SelectByID(queryStructs.ID).FileSize);
            var queryMembers = queryStructs.EmdMembers.Where(item => item.IsSelected).FirstOrDefault();
            if (queryMembers == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, retVal);
            }
            retVal.ActiveMember = queryMembers.CreateViewModel();
            var querySections = queryMembers.EmdSections.Where(item => item.IsSelected).FirstOrDefault();
            if (querySections == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, retVal);
            }
            retVal.ActiveSection = querySections.CreateViewModel();
            return Request.CreateResponse(HttpStatusCode.OK, retVal);
        }
        #endregion
    }
}

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SciaDesignFormsModel.Abstract;
using SciaDesignFormsModel.ViewModels.EsaModelData;

namespace SciaDesignFormsWeb.Areas.EmdDataManager.Controllers
{
    [Authorize]
    public class EmdSectionsController : ApiController
    {
        public EmdSectionsController(
            IDbEmdMemberRepository repoMember,
            IDbEmdSectionRepository repoSection)
        {
            m_repoMember = repoMember;
            m_repoSection = repoSection;
        }

        #region MEMBERS
        readonly IDbEmdMemberRepository m_repoMember;
        readonly IDbEmdSectionRepository m_repoSection;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">member ID</param>
        /// <returns></returns>
        public HttpResponseMessage GetEmdSections(int id)
        {
            var query = m_repoMember.SelectByID(id);
            if (query == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                new HttpError
                {
                    Message = "Invalid input !",
                    MessageDetail = string.Format("There are no sections for member with ID {0} was found", id)
                });
            }
            return Request.CreateResponse(HttpStatusCode.OK, query.EmdSections.Select(item => item.CreateViewModel()));
        }
        public HttpResponseMessage PostSection(DbEmdSectionViewModel section)
        {
            if (section == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                new HttpError
                {
                    Message = "Invalid input - input is null",
                });
            }
            var query = m_repoSection.SelectByID(section.ID);
            if (query == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                new HttpError
                {
                    Message = "No such data item",
                    MessageDetail = string.Format("No item with ID {0} was found", section.ID)
                });
            }
            query.UpdateDb(section);
            m_repoSection.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        protected override void Dispose(bool disposing)
        {
            m_repoMember.Dispose();
            m_repoSection.Dispose();
            base.Dispose(disposing);
        }
    }
}

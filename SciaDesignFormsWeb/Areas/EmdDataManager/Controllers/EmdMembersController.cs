using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SciaDesignFormsModel.Abstract.Repositories;
using SciaDesignFormsModel.ViewModels.EsaModelData;

namespace SciaDesignFormsWeb.Areas.EmdDataManager.Controllers
{
    [Authorize]
    //[RoutePrefix("EmdDataManager/api/EmdMembers")]
    public class EmdMembersController : ApiController
    {
        public EmdMembersController(
            IDbEmdStructureRepository repoStructures,
            IDbEmdMemberRepository repoMember)
        {
            m_repoStructures = repoStructures;
            m_repoMember = repoMember;
        }
        
        #region MEMBERS
        readonly IDbEmdStructureRepository m_repoStructures;
        readonly IDbEmdMemberRepository m_repoMember;
        #endregion
        
        //[HttpGet]
        //[Route("GetEmdMembers/{id}")]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">structure ID</param>
        /// <returns></returns>
        public HttpResponseMessage GetEmdMembers(int id)
        {
            var query = m_repoStructures.SelectByID(id);
            if (query == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                new HttpError
                {
                    Message = "Invalid input !",
                    MessageDetail = string.Format("There are no members for structure with ID {0} was found", id)
                });
            }
            return Request.CreateResponse(HttpStatusCode.OK, query.EmdMembers.Select(item => item.CreateViewModel()));
        }
        public HttpResponseMessage PostMember(DbEmdMemberViewModel member)
        {
            if (member == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                new HttpError
                {
                    Message = "Invalid input - input is null",
                });
            }
            var query = m_repoMember.SelectByID(member.ID);
            if (query == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                new HttpError
                {
                    Message = "No such data item",
                    MessageDetail = string.Format("No item with ID {0} was found", member.ID)
                });
            }
            query.UpdateDb(member);
            m_repoMember.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        protected override void Dispose(bool disposing)
        {
            m_repoStructures.Dispose();
            m_repoMember.Dispose();
            base.Dispose(disposing);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using SciaDesignFormsModel.Abstract.Repositories;
using SciaDesignFormsModel.ViewModels.SdfChecks;

namespace SciaDesignFormsModel.Controllers
{
    public class SdfUserChecksController : ApiController
    {
        public SdfUserChecksController(
            IDbSdfUserChecksRepository repoSdfChecks)
        {
            m_repoSdfUserChecks = repoSdfChecks;
        }

        #region MEMBERS
        readonly IDbSdfUserChecksRepository m_repoSdfUserChecks;
        #endregion

        #region INTERFACE
        public IEnumerable<DbSdfUserCheckViewModel> GetSdfUserChecks()
        {
            string userID = User.Identity.GetUserId();
            var query = m_repoSdfUserChecks.DataQueryable().Where((item) => item.ApplicationUser.Id == userID).ToList().Select(item => item.CreateViewModel());
            return query;
        }
        public DbSdfUserCheckViewModel GetSdfUserCheck(int? id)
        {
            if (id == null)
            {
                return null;
            }
            string userID = User.Identity.GetUserId();
            var query = m_repoSdfUserChecks.DataQueryable().Where(item => (item.ApplicationUser.Id == userID) && (item.ID == id)).FirstOrDefault();
            if (query == null)
            {
                return null;
            }
            return (query == null) ? (null) : (query.CreateViewModel());
        }
        #endregion
       
        #region METHODS
        protected override void Dispose(bool disposing)
        {
            m_repoSdfUserChecks.Dispose();
            base.Dispose(disposing);
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using SciaDesignFormsModel.Abstract.Repositories;
using SciaDesignFormsModel.ViewModels.SdfChecks;

namespace SciaDesignFormsModel.Controllers
{
    public class SdfChecksController : ApiController
    {
        public SdfChecksController(
            IDbSdfUserChecksRepository repoSdfUserChecks)
        {
            m_repoSdfUserChecks = repoSdfUserChecks;
        }

        #region MEMBERS
        readonly IDbSdfUserChecksRepository m_repoSdfUserChecks;
        #endregion


        public IEnumerable<DbSdfCheckViewModel> GetSdfChecks()
        {
            string userID = User.Identity.GetUserId();
            return m_repoSdfUserChecks.DataQueryable().Where((item) => item.ApplicationUser.Id == userID).Select(item => item.SdfCheck.CreateViewModel());
        }
        public DbSdfCheckViewModel GetSdfCheck(string id)
        {
            string userID = User.Identity.GetUserId();
            var query = m_repoSdfUserChecks.DataQueryable().Where((item) => (item.ApplicationUser.Id == userID) && (item.SdfCheckID.ToString() == id)).Select(item => item.SdfCheck).FirstOrDefault();
            if (query == null)
            {
                return null;
            }
            return (query == null) ? (null) : (query.CreateViewModel());
        }

        protected override void Dispose(bool disposing)
        {
            m_repoSdfUserChecks.Dispose();
            base.Dispose(disposing);
        }
    }
}

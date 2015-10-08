using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using SciaDesignFormsModel.Abstract;
using SciaDesignFormsModel.Entities.Identity.EmdFileStructure;
using SciaDesignFormsModel.ViewModels.EsaModelData;

namespace SciaDesignFormsWeb.Areas.EmdDataManager.Controllers
{
    [Authorize]
    public class EmdFileRangesController : ApiController
    {
        public EmdFileRangesController(
            IDbEmdFileRepository repoFiles,
            IDbEmdFileRangeRepository repoRange)
        {
            m_repoRange = repoRange;
            m_repoFiles = repoFiles;
        }

        #region MEMBERS
        readonly IDbEmdFileRangeRepository m_repoRange;
        readonly IDbEmdFileRepository m_repoFiles;
        #endregion


        public IEnumerable<DbEmdFileRangeViewModel> GetEmdFileRanges()
        {
            try
            {
                string userID = User.Identity.GetUserId();
                var queryFiles4User = m_repoFiles.DataQueryable().Where(item => item.ApplicationUserID == userID).ToList();
                if (queryFiles4User == null)
                {
                    return null;
                }
                var queryRanges4User = m_repoRange.DataQueryable().Where(item => item.Id == userID).ToList();
                if (queryRanges4User == null)
                {
                    return null;
                }
                long filesSizes = queryFiles4User.Sum(item => item.FileSize);
                return queryRanges4User.Select(item => item.CreateViewModel(filesSizes));
            }
            catch (DataException)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return null;
            }
        }

        protected override void Dispose(bool disposing)
        {
            m_repoRange.Dispose();
            m_repoFiles.Dispose();
            base.Dispose(disposing);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using SciaDesignFormsModel.Abstract.Repositories;
using SciaDesignFormsModel.ViewModels.EsaModelData;

namespace SciaDesignFormsWeb.Areas.EmdDataManager.Controllers
{
    [Authorize]
    public class EmdStructuresController : ApiController
    {
        public EmdStructuresController(
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


        public IEnumerable<DbEmdStructureViewModel> GetEmdStructures()
        {
            string userID = User.Identity.GetUserId();
            var queryFiles4User = m_repoFiles.DataQueryable().Where(item => item.ApplicationUserID == userID).ToList();
            if (queryFiles4User == null)
	        {
		        return null;    
	        }
            return queryFiles4User.Select(item => item.Structure.CreateViewModel(item.FileSize));
        }
        public DbEmdStructureViewModel GetEmdStructure(int id)
        {
            string userID = User.Identity.GetUserId();
            var query = m_repoFiles.DataQueryable().Where(item => item.ApplicationUserID == userID).Where(item => item.Structure.ID == id).FirstOrDefault();
            return (query == null) ? (null) : (query.Structure.CreateViewModel(query.FileSize));
        }
        public void PostStructure(DbEmdStructureViewModel structure)
        {
            string userID = User.Identity.GetUserId();
            var query = m_repoFiles.DataQueryable().Where(item => item.ApplicationUserID == userID).Where(item => item.Structure.ID == structure.ID).FirstOrDefault();
            if (query == null)
            {
                return;
            }
            query.Structure.UpdateDb(structure);
            m_repoFiles.SaveChanges();
        }
        public void DeleteStructure(int id)
        {
            var structQuery = m_repoStructs.SelectByID(id);
            if (structQuery == null)
            {
                return;
            }
            m_repoStructs.Delete(id);
            m_repoStructs.SaveChanges();
            m_repoFiles.Delete(id);
            m_repoFiles.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            m_repoFiles.Dispose();
            m_repoStructs.Dispose();
            base.Dispose(disposing);
        }
    }
}

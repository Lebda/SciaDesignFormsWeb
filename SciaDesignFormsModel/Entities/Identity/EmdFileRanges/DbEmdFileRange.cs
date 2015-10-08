using System;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SciaDesignFormsModel.Entities.Identity.EmdFileRanges
{
    public class DbEmdFileRange
    {
        public DbEmdFileRange()
        {
            EmdFilesLimit = 2000000; // Bytes (2MB)
        }

        public string Id { get; set; }

        public long EmdFilesLimit { get; set; }

        #region NAVIGATIONS
        public virtual IdentityUser ApplicationUser { get; set; }
        #endregion
    }
}

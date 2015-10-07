using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using SciaDesignFormsModel.Entities.Identity.DbEmdUserSelection;

namespace SciaDesignFormsModel.Entities.Identity.DbFiles
{
    public class DbEmdFile
    {
        public int ID { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public string Description { get; set; }

        #region NAVIGATION
        public string ApplicationUserID { get; set; }
        public virtual IdentityUser ApplicationUser { get; set; }
        public string EmdSelectionID { get; set; }
        public virtual DbEmdSelection EmdSelection { get; set; }
        #endregion
    }
}

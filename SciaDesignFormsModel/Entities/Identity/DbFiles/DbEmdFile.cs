using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using SciaDesignFormsModel.Entities.Identity.EmdFileStructure;

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

        #region NAVIGATION
        public string ApplicationUserID { get; set; }
        public virtual IdentityUser ApplicationUser { get; set; }
        public virtual DbEmdStructure Structure { get; set; }
        #endregion
    }
}

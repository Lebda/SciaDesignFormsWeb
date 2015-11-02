using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SciaDesignFormsModel.Entities.Identity.SdfCheck
{
    public class DbSdfUserCheck
    {
        public DbSdfUserCheck()
        {
            IsActive = false;
        }
        [Key]
        public int ID { get; set; }
        public bool IsActive { get; set; }

        #region NAVIGATION
        public Guid SdfCheckID { get; set; }
        public virtual DbSdfCheck SdfCheck { get; set; }
        public string ApplicationUserID { get; set; }
        public virtual IdentityUser ApplicationUser { get; set; }
        #endregion
    }
}

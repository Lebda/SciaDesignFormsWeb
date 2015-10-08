using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SciaDesignFormsModel.Entities.Identity.EmdFileStructure
{
    public class DbEmdSection
    {
        public DbEmdSection()
        {
            Position = 0.0;
            Index = 0;
            IsSelected = false;
        }
        public int ID { get; set; }
        [Required]
        public double Position { get; set; }
        [Required]
        public long Index { get; set; }
        public bool IsSelected { get; set; }

        #region NAVIGATION
        public int MemberID { get; set; }
        public virtual DbEmdMember Member { get; set; }
        #endregion
    }
}

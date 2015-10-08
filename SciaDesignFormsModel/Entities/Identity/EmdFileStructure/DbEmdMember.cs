using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SciaDesignFormsModel.Entities.Identity.EmdFileStructure
{
    public class DbEmdMember
    {
        public DbEmdMember()
        {
            Name = String.Empty;
            IsSelected = false;
        }

        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsSelected { get; set; }

        #region NAVIGATION
        public virtual ICollection<DbEmdSection> EmdSections { get; set; }
        public int EmdStructureID { get; set; }
        public virtual DbEmdStructure EmdStructure { get; set; }
        #endregion
    }
}

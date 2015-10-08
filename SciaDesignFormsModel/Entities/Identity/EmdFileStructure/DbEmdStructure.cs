using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SciaDesignFormsModel.Entities.Identity.DbFiles;

namespace SciaDesignFormsModel.Entities.Identity.EmdFileStructure
{
    public class DbEmdStructure
    {
        public DbEmdStructure()
        {
            Name = String.Empty;
            IsSelected = false;
            Description = String.Empty;
        }

        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsSelected { get; set; }

        #region NAVIGATION
        public virtual ICollection<DbEmdMember> EmdMembers { get; set; }
        public virtual DbEmdFile EmdFile { get; set; }
        #endregion
    }
}

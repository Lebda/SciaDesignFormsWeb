using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SciaDesignFormsModel.Entities.Identity.SdfCheck
{
    public class DbSdfCheck
    {
        public DbSdfCheck()
        {
            UserChecks = new List<DbSdfUserCheck>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)][Key]
        public Guid ID { get; set; }
        public string CheckName { get; set; }
        public string Version { get; set; }

        #region NAVIGATION
        public virtual ICollection<DbSdfUserCheck> UserChecks { get; set; }
        #endregion
    }
}

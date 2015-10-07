using System;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using SciaDesignFormsModel.Entities.Identity.DbFiles;

namespace SciaDesignFormsModel.Entities.Identity.DbEmdUserSelection
{
    public class DbEmdSelection
    {
        public string ID { get; set; }

        #region NAVIGATIONS
        public virtual IdentityUser ApplicationUser { get; set; }
        public int EmdFileID { get; set; }
        public virtual DbEmdFile EmdFile { get; set; }
        #endregion


        //public string EmdStructureID { get; set; }
        //[ForeignKey("EmdStructureID")]
        //public virtual DbEmdStructure EmdStructure { get; set; }

        //public string EmdMemberID { get; set; }
        //[ForeignKey("EmdMemberID")]
        //public virtual DbEmdMember EmdMember { get; set; }

        //public string EmdSectionID { get; set; }
        //[ForeignKey("EmdSectionID")]
        //public virtual DbEmdSection EmdSection { get; set; }

    }
}

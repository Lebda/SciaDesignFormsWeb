using System;
using System.Linq;

namespace SciaDesignFormsModel.Entities.Identity.DbEmdUserSelection
{
    public class DbEmdStructure
    {
       // [Key, ForeignKey("Selection")]
        public int ID { get; set; }

        //public virtual DbEmdSelection Selection { get; set; }
        //public virtual ICollection<DbEmdMember> DbEmdMembers { get; set; }
    }
}

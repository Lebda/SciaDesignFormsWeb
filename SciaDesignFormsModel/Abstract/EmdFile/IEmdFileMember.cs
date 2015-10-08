using System.Collections.Generic;
using System.Linq;
using SciaDesignFormsModel.Entities.Identity.EmdFileStructure;

namespace SciaDesignFormsModel.Abstract.EmdFile
{
    public interface IEmdFileMember
    {
        DbEmdMember CreateDb();
        ICollection<IEmdFileSection> Sections { get; set; }
        string Name { get; set; }
    }
}
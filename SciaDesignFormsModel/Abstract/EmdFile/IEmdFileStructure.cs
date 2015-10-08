using System.Collections.Generic;
using System.Linq;
using SciaDesignFormsModel.Entities.Identity.EmdFileStructure;

namespace SciaDesignFormsModel.Abstract.EmdFile
{
    public interface IEmdFileStructure
    {
        DbEmdStructure CreateDb();
        string Name { get; set; }
        ICollection<IEmdFileMember> Members { get; set; }
    }
}
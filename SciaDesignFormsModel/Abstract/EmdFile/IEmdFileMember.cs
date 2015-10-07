using System.Collections.Generic;

namespace SciaDesignFormsModel.Abstract.EmdFile
{
    public interface IEmdFileMember
    {
        ICollection<IEmdFileSection> Sections { get; set; }
        string Name { get; set; }
    }
}
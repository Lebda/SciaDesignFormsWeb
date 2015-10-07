using System.Collections.Generic;

namespace SciaDesignFormsModel.Abstract.EmdFile
{
    public interface IEmdFileStrcture
    {
        string Name { get; set; }
        ICollection<IEmdFileMember> Members { get; set; }
    }
}
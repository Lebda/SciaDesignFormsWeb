using System.IO;

namespace SciaDesignFormsModel.Abstract.EmdFile
{
    public interface IEmdFileContext
    {
        Stream EmdFileStream { get; set; }
        string ZipFileName { get; set; }
    }
}
using System;
using System.IO;
using System.Linq;
using SciaDesignFormsModel.Abstract.EmdFile;

namespace SciaDesignFormsModel.Concrete.EmdFile
{
    public class EmdFileContext : IEmdFileContext
    {
        #region PROPERTIES
        public Stream EmdFileStream { get; set; }
        public string ZipFileName { get; set; }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using SciaDesignFormsModel.Abstract.EmdFile;

namespace SciaDesignFormsModel.Concrete.EmdFile
{
    class EmdFileStrcture : IEmdFileStrcture
    {
        public EmdFileStrcture()
        {
            Members = new List<IEmdFileMember>();
            Name = String.Empty;
        }

        #region PROPERTIES
        public ICollection<IEmdFileMember> Members { get; set; }
        public string Name { get; set; }
        #endregion
    }
}

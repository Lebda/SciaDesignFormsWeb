using System;
using System.Collections.Generic;
using System.Linq;
using SciaDesignFormsModel.Abstract.EmdFile;

namespace SciaDesignFormsModel.Concrete.EmdFile
{
    class EmdFileMember : IEmdFileMember
    {
        public EmdFileMember()
        {
            Sections = new List<IEmdFileSection>();
        }

        #region PROPERTIES
        public ICollection<IEmdFileSection> Sections { get; set; }
        public string Name { get; set; }
        #endregion
    }
}

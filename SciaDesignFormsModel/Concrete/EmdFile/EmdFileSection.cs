using System;
using System.Linq;
using SciaDesignFormsModel.Abstract.EmdFile;

namespace SciaDesignFormsModel.Concrete.EmdFile
{
    class EmdFileSection : IEmdFileSection
    {
        public EmdFileSection()
        {
            Position = 0.0;
            Index = 0;
        }

        #region PROPERTIES
        public double Position { get; set; }
        public long Index { get; set; }
        #endregion
    }
}

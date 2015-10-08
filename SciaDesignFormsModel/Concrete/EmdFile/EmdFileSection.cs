using System;
using System.Linq;
using SciaDesignFormsModel.Abstract.EmdFile;
using SciaDesignFormsModel.Entities.Identity.EmdFileStructure;

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

        #region INTERFACE
        public DbEmdSection CreateDb()
        {
            DbEmdSection retVal = new DbEmdSection();
            retVal.IsSelected = false;
            retVal.Position = Position;
            retVal.Index = Index;
            return retVal;
        }
        #endregion
    }
}

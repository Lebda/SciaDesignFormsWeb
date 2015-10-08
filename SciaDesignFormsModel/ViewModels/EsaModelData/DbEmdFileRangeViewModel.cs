using System;
using System.Linq;

namespace SciaDesignFormsModel.ViewModels.EsaModelData
{
    public class DbEmdFileRangeViewModel
    {
        public DbEmdFileRangeViewModel()
        {
            EmdFilesLimit = 0;
            EmdFilesSize = 0;
        }

        #region PROPERTIES
        public long EmdFilesLimit { get; set; }
        public long EmdFilesSize { get; set; }
        #endregion
    }
}

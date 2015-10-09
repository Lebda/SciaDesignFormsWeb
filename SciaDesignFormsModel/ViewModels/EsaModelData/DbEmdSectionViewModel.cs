using System;
using System.Linq;

namespace SciaDesignFormsModel.ViewModels.EsaModelData
{
    public class DbEmdSectionViewModel
    {
        public DbEmdSectionViewModel()
        {
            Position = 0.0;
            Index = 0;
            IsSelected = false;
            ID = -1;
        }

        #region PROPERTIES
        public int ID { get; set; }
        public double Position { get; set; }
        public long Index { get; set; }
        public bool IsSelected { get; set; }
        #endregion
    }
}

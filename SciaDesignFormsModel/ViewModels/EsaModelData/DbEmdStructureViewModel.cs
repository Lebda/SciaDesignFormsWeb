using System;
using System.Linq;

namespace SciaDesignFormsModel.ViewModels.EsaModelData
{
    public class DbEmdStructureViewModel
    {
        public DbEmdStructureViewModel()
        {
            Name = String.Empty;
            IsSelected = false;
            ID = -1;
            Description = String.Empty;
            FileSize = 0;
        }

        #region PROPERTIES
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
        public string Description { get; set; }
        public long FileSize { get; set; }
        #endregion
    }
}

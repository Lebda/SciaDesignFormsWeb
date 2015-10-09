using System;
using System.Linq;

namespace SciaDesignFormsModel.ViewModels.EsaModelData
{
    public class DbEmdMemberViewModel
    {
        public DbEmdMemberViewModel()
        {
            Name = String.Empty;
            IsSelected = false;
            ID = -1;
        }

        #region PROPERTIES
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
        #endregion
    }
}

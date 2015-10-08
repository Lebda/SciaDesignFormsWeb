using System;
using System.Collections.Generic;
using System.Linq;

namespace SciaDesignFormsModel.ViewModels.EsaModelData
{
    public class DbEmdStructureViewModel
    {
        public DbEmdStructureViewModel()
        {
            Members = new List<DbEmdMemberViewModel>();
            Name = String.Empty;
            IsSelected = false;
            ID = -1;
            Description = String.Empty;
        }

        #region PROPERTIES
        public ICollection<DbEmdMemberViewModel> Members { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
        public string Description { get; set; }
        #endregion
    }
}

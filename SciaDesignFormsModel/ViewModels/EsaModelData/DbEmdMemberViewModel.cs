using System;
using System.Collections.Generic;
using System.Linq;

namespace SciaDesignFormsModel.ViewModels.EsaModelData
{
    public class DbEmdMemberViewModel
    {
        public DbEmdMemberViewModel()
        {
            Sections = new List<DbEmdSectionViewModel>();
            Name = String.Empty;
            IsSelected = false;
        }

        #region PROPERTIES
        public ICollection<DbEmdSectionViewModel> Sections { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
        #endregion
    }
}

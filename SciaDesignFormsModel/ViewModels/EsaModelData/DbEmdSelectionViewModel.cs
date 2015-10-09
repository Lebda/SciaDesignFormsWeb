using System;
using System.Linq;

namespace SciaDesignFormsModel.ViewModels.EsaModelData
{
    public class DbEmdSelectionViewModel
    {

        #region PROPERTIES
        public DbEmdStructureViewModel ActiveStructure { get; set; }
        public DbEmdMemberViewModel ActiveMember { get; set; }
        public DbEmdSectionViewModel ActiveSection { get; set; }
        #endregion

    }
}

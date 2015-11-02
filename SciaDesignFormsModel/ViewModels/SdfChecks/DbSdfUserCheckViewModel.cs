using System;
using System.Linq;

namespace SciaDesignFormsModel.ViewModels.SdfChecks
{
    public class DbSdfUserCheckViewModel
    {
        public DbSdfUserCheckViewModel()
        {
            ID = -1;
            CheckName = String.Empty;
            IsActive = false;
        }

        #region PROPERTIES
        public int ID { get; set; }
        public string CheckName { get; set; }
        public bool IsActive { get; set; }
        #endregion
    }
}

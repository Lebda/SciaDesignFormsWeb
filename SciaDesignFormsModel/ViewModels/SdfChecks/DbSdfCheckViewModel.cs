using System;
using System.Linq;

namespace SciaDesignFormsModel.ViewModels.SdfChecks
{
    public class DbSdfCheckViewModel
    {
        public DbSdfCheckViewModel()
        {
            CheckName = String.Empty;
            Version = String.Empty;
            ID = String.Empty;
        }

        #region PROPERTIES
        public string ID { get; set; }
        public string CheckName { get; set; }
        public string Version { get; set; }
        #endregion
    }
}

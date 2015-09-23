using System;
using System.Collections.Generic;
using System.Linq;
using SdfCalculationService.Abstract.HttpCalculation;

namespace SdfCalculationService.Concrete.HttpCalculation
{
    class WebApiChecksData : IWebApiChecksData
    {
        public WebApiChecksData()
        {
            Checks = new List<IWebApiCheckData>();
        }

        #region PROPERTIES
        public ICollection<IWebApiCheckData> Checks { get; set; }
        #endregion
    }
}

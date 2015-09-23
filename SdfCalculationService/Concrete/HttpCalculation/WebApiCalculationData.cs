using System;
using System.Linq;
using SdfCalculationService.Abstract.HttpCalculation;

namespace SdfCalculationService.Concrete.HttpCalculation
{
    class WebApiCalculationData : IWebApiCalculationData
    {
        #region PROPERTIES
        public IWebApiChecksData ChecksData { get; set; }
        #endregion
    }
}
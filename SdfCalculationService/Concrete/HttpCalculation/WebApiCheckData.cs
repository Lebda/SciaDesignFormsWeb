using System;
using System.Linq;
using SdfCalculationService.Abstract.HttpCalculation;
using SdfCalculationService.Abstract.Shared;

namespace SdfCalculationService.Concrete.HttpCalculation
{
    class WebApiCheckData : IWebApiCheckData
    {
        public WebApiCheckData()
        {
            Name = "No name";
            CheckValue = 0.0;
            IsOn = true;
        }

        #region INTERFACE
        public string Name { get; set; }
        public double CheckValue { get; set; }
        public bool IsOn { get; set; }
        public ICalculationContext Context { get; set; }
        #endregion
    }
}

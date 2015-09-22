using System;
using System.Linq;
using SdfCalculationService.Abstract;

namespace SdfCalculationService.Concrete
{
    public class CheckValueCalculator : ICheckValueCalculator
    {
        #region INTERFACE
        public double Calculate(ICalculationContext context)
        {
            return new Random().NextDouble();
        }
        #endregion
    }
}

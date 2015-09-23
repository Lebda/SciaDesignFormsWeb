using System;
using SdfCalculationService.Abstract.Shared;

namespace SdfCalculationService.Abstract
{
    public interface ICheckValueCalculator
    {
        double Calculate(ICalculationContext context);
    }
}
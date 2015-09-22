using System;

namespace SdfCalculationService.Abstract
{
    public interface ICheckValueCalculator
    {
        double Calculate(ICalculationContext context);
    }
}
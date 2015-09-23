using SdfCalculationService.Abstract.Shared;

namespace SdfCalculationService.Abstract.HttpCalculation
{
    public interface IWebApiCheckData
    {
        string Name { get; set; }
        double CheckValue { get; set; }
        bool IsOn { get; set; }
        ICalculationContext Context { get; set; }
    }
}
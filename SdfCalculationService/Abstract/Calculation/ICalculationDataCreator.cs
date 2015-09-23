using SdfCalculationService.Abstract.HttpCalculation;

namespace SdfCalculationService.Abstract.Calculation
{
    public interface ICalculationDataCreator
    {
        IWebApiCalculationData GetWebApi();
    }
}
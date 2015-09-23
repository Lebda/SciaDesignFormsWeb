using SdfCalculationService.General;

namespace SdfCalculationService.Abstract.Shared
{
    public interface ICalculationContext
    {
        long ClcID { get; set; }
        long CombiID { get; set; }
        eOutPutType OutPutType { get; set; }
    }
}
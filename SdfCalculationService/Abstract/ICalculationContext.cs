using SdfCalculationService.General;

namespace SdfCalculationService.Abstract
{
    public interface ICalculationContext
    {
        long ClcID { get; set; }
        long CombiID { get; set; }
        eOutPutType OutPutType { get; set; }
    }
}
using System.Collections.Generic;

namespace SdfCalculationService.Abstract.HttpCalculation
{
    public interface IWebApiChecksData
    {
        ICollection<IWebApiCheckData> Checks { get; set; }
    }
}
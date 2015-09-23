using System;
using System.Linq;
using SdfCalculationService.Abstract.Shared;
using SdfCalculationService.General;

namespace SdfCalculationService.Concrete.Shared
{
    public class CalculationContext : ICalculationContext
    {
        public CalculationContext()
        {
            ClcID = -1;
            CombiID = -1;
            OutPutType = eOutPutType.eBrief;
        }

        #region PROPERTIES
        public long ClcID { get; set; }
        public long CombiID { get; set; }
        public eOutPutType OutPutType { get; set; }
        #endregion
    }
}

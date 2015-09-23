using System;
using System.Linq;
using Ioc_Help.Abstract;
using SdfCalculationService.Abstract.Calculation;
using SdfCalculationService.Abstract.HttpCalculation;
using SdfCalculationService.Abstract.Shared;
using SdfCalculationService.General;

namespace SdfCalculationService.Concrete.Calculation
{
    public class CalculationDataCreator : ICalculationDataCreator
    {
        public CalculationDataCreator(
            IResolver<IWebApiCalculationData> resCalculationData,
            IResolver<ICalculationContext> resCalculationContext,
            IResolver<IWebApiCheckData> resCheckData,
            IResolver<IWebApiChecksData> resChecksData
            )
        {
            m_resCalculationContext = resCalculationContext;
            m_resCheckData = resCheckData;
            m_resChecksData = resChecksData;
            m_resCalculationData = resCalculationData;
        }

        #region MEMBERS;
        readonly IResolver<ICalculationContext> m_resCalculationContext;
        readonly IResolver<IWebApiCheckData> m_resCheckData;
        readonly IResolver<IWebApiChecksData> m_resChecksData;
        readonly IResolver<IWebApiCalculationData> m_resCalculationData;
        #endregion

        #region INTERFACE
        public IWebApiCalculationData GetWebApi()
        {
            IWebApiChecksData checks = m_resChecksData.Resolve();
            checks.Checks.Add(CreateCheckData("Check capacity response", 0.9, true, CreateContext(1, 1, eOutPutType.eBrief)));
            checks.Checks.Add(CreateCheckData("Check capacity diagram", 0.8, true, CreateContext(1, 1, eOutPutType.eBrief)));
            checks.Checks.Add(CreateCheckData("Check shear", 0.7, true, CreateContext(1, 1, eOutPutType.eBrief)));
            checks.Checks.Add(CreateCheckData("Check torsion", 0.6, true, CreateContext(1, 1, eOutPutType.eBrief)));
            IWebApiCalculationData retVal = m_resCalculationData.Resolve();
            retVal.ChecksData = checks;
            return retVal;
        }
        #endregion

        #region METHODS
        IWebApiCheckData CreateCheckData(string name, double checkValue, bool isOn, ICalculationContext context)
        {
            IWebApiCheckData retVal = m_resCheckData.Resolve();
            retVal.Name = name;
            retVal.CheckValue = checkValue;
            retVal.IsOn = isOn;
            retVal.Context = context;
            return retVal;
        }
        ICalculationContext CreateContext(long clcID, long combiID, eOutPutType outPutType)
        {
            ICalculationContext retVal = m_resCalculationContext.Resolve();
            retVal.ClcID = clcID;
            retVal.CombiID = combiID;
            retVal.OutPutType = outPutType;
            return retVal;
        }
        #endregion
    }
}

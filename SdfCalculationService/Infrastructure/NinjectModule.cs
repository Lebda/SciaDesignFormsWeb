using System;
using System.Linq;
using Ninject;
using SdfCalculationService.Abstract;
using SdfCalculationService.Abstract.Calculation;
using SdfCalculationService.Abstract.Document;
using SdfCalculationService.Abstract.HttpCalculation;
using SdfCalculationService.Abstract.HttpDocument;
using SdfCalculationService.Abstract.Shared;
using SdfCalculationService.Concrete;
using SdfCalculationService.Concrete.Calculation;
using SdfCalculationService.Concrete.Document;
using SdfCalculationService.Concrete.HttpCalculation;
using SdfCalculationService.Concrete.HttpDocument;
using SdfCalculationService.Concrete.Shared;

namespace SdfCalculationService.Infrastructure
{
    static public class NinjectModule
    {
        static public void Bindings(IKernel kernel)
        {
            kernel.Bind<ICalculationContext>().To<CalculationContext>();
            kernel.Bind<ICheckValueCalculator>().To<CheckValueCalculator>();
            kernel.Bind<IPictureData>().To<PictureData>();
            kernel.Bind<IDocumentPictureContext>().To<DocumentPictureContext>();
            kernel.Bind<IDocumentPicturesCreator>().To<DocumentPicturesCreator>();
            kernel.Bind<IWebApiPictureData>().To<WebApiPictureData>();
            kernel.Bind<IWebApiPictureContext>().To<WebApiPictureContext>();
            kernel.Bind<IWebApiDocument>().To<WebApiDocument>();
            kernel.Bind<IWebApiCheckData>().To<WebApiCheckData>();
            kernel.Bind<IWebApiChecksData>().To<WebApiChecksData>();
            kernel.Bind<IWebApiCalculationData>().To<WebApiCalculationData>();
            kernel.Bind<ICalculationDataCreator>().To<CalculationDataCreator>();
        }
    }
}

using System;
using System.Linq;
using Ninject;
using SdfCalculationService.Abstract;
using SdfCalculationService.Concrete;

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
        }
    }
}

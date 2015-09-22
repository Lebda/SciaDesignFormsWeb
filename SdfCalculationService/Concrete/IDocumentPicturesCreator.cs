using SdfCalculationService.Abstract;
using SdfCalculationService.Concrete.HttpDocument;

namespace SdfCalculationService.Concrete
{
    public interface IDocumentPicturesCreator
    {
        IDocumentPictureContext Run(ICalculationContext context);
        WebApiDocument GetWebApiDocument(ICalculationContext context);
    }
}
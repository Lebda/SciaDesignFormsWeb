using SdfCalculationService.Abstract.HttpDocument;
using SdfCalculationService.Abstract.Shared;

namespace SdfCalculationService.Abstract.Document
{
    public interface IDocumentPicturesCreator
    {
        IDocumentPictureContext Run(ICalculationContext context);
        IWebApiDocument GetWebApiDocument(ICalculationContext context);
    }
}
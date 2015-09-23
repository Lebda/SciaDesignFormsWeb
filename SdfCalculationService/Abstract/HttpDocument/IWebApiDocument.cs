using System.Collections.Generic;
using System.Linq;

namespace SdfCalculationService.Abstract.HttpDocument
{
    public interface IWebApiDocument
    {
        ICollection<IWebApiPictureContext> Pictures { get; set; }
        double CanvasWidth { get; set; }
        double CanvasHeight { get; set; }
        double CanvasOffsetHeight { get; set; }
        double CanvasOffsetWidth { get; set; }
        void CalculateBounds();
    }
}
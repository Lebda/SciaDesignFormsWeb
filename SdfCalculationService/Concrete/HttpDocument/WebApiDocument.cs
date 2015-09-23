using System;
using System.Collections.Generic;
using System.Linq;
using SdfCalculationService.Abstract.HttpDocument;

namespace SdfCalculationService.Concrete.HttpDocument
{
    class WebApiDocument : IWebApiDocument
    {
        public WebApiDocument()
        {
            Pictures = new List<IWebApiPictureContext>();
            CanvasWidth = 0.0;
            CanvasHeight = 0.0;
            CanvasOffsetHeight = 100.0;
            CanvasOffsetWidth = 100.0;
        }

        #region PROPERTIES
        public ICollection<IWebApiPictureContext> Pictures { get; set; }
        public double CanvasWidth { get; set; }
        public double CanvasHeight { get; set; }
        public double CanvasOffsetHeight { get; set; }
        public double CanvasOffsetWidth { get; set; }
        #endregion

        #region INTERFACE
        public void CalculateBounds()
        {
            CanvasWidth = Pictures.Max(x => x.Location.BoundsWidth) + CanvasOffsetWidth;
            CanvasHeight = 500.0;
            if (Pictures.Last() != null)
            {
                CanvasHeight = Pictures.Last().Location.BoundsLocationY + Pictures.Last().Location.BoundsHeight;
                CanvasHeight += CanvasOffsetHeight;   
            }
        }
        #endregion
    }
}

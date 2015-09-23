using System;
using System.Linq;
using SdfCalculationService.Abstract.HttpDocument;

namespace SdfCalculationService.Concrete.HttpDocument
{
    public class WebApiPictureData : IWebApiPictureData
    {
        public WebApiPictureData()
        {
            BoundsWidth = 0.0;
            BoundsHeight = 0.0;
            BoundsLocationX = 0.0;
            BoundsLocationY = 0.0;
        }

        #region PROPERTIES
        public double BoundsWidth { get; set; }
        public double BoundsHeight { get; set; }
        public double BoundsLocationX { get; set; }
        public double BoundsLocationY { get; set; }
        #endregion
    }
}

using System;
using System.Linq;
using SdfCalculationService.Abstract.Document;

namespace SdfCalculationService.Concrete.Document
{
    class PictureData : IPictureData
    {
        public PictureData()
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

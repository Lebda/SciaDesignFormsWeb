using System;
using System.Linq;

namespace SdfCalculationService.Concrete.HttpDocument
{
    public class WebApiPictureContext
    {
        #region PROPERTIES
        public string Base64String { get; set; }
        public WebApiPictureData Location { get; set; }
        #endregion
    }
}

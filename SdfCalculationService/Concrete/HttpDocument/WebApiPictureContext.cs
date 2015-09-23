using System;
using System.Linq;
using SdfCalculationService.Abstract.HttpDocument;

namespace SdfCalculationService.Concrete.HttpDocument
{
    public class WebApiPictureContext : IWebApiPictureContext
    {
        #region PROPERTIES
        public string Base64String { get; set; }
        public IWebApiPictureData Location { get; set; }
        #endregion
    }
}

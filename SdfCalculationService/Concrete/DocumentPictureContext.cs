using System;
using System.Drawing;
using System.IO;
using System.Linq;
using SdfCalculationService.Abstract;

namespace SdfCalculationService.Concrete
{
    public class DocumentPictureContext : IDocumentPictureContext
    {
        public DocumentPictureContext(IPictureData data)
        {
            Location = data;
        }

        #region PROPERTIES
        public string Base64String { get; set; }
        public Image ImageData { get; set; }
        public byte[] BinaryData { get; set; }
        public MemoryStream BinaryStream { get; set; }
        public IPictureData Location { get; set; }
        #endregion
    }
}

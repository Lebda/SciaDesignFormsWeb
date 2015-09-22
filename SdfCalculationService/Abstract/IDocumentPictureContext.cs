using System.Drawing;
using System.IO;

namespace SdfCalculationService.Abstract
{
    public interface IDocumentPictureContext
    {
        string Base64String { get; set; }
        Image ImageData { get; set; }
        byte[] BinaryData { get; set; }
        MemoryStream BinaryStream { get; set; }
        IPictureData Location { get; set; }
    }
}
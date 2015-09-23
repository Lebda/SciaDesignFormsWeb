using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Ioc_Help.Abstract;
using SdfCalculationService.Abstract.Document;
using SdfCalculationService.Abstract.HttpDocument;
using SdfCalculationService.Abstract.Shared;
using SdfCalculationService.Concrete.HttpDocument;

namespace SdfCalculationService.Concrete.Document
{
    public class DocumentPicturesCreator : IDocumentPicturesCreator
    {
        public DocumentPicturesCreator(
            IResolver<IDocumentPictureContext> resDocumentPictureContext,
            IResolver<IWebApiDocument> resWebApiDocument
            )
        {
            m_resWebApiDocument = resWebApiDocument;
            m_resDocumentPictureContext = resDocumentPictureContext;
        }

        #region MEMBERS
        readonly IResolver<IDocumentPictureContext> m_resDocumentPictureContext;
        readonly IResolver<IWebApiDocument> m_resWebApiDocument;
        #endregion

        #region INTERFACE
        public IDocumentPictureContext Run(ICalculationContext context)
        {
            IDocumentPictureContext retval = m_resDocumentPictureContext.Resolve();
            Image img = new Bitmap(@"C:\Users\jlebduska\Documents\Visual Studio 2013\Projects\SectionCheckWeb\SectionCheckWeb\Content\Images\2010_tangled_0006.jpg");
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            retval.BinaryStream = ms;
            retval.BinaryData = ms.ToArray();
            retval.Location.BoundsHeight = 100;
            retval.Location.BoundsWidth = 100;
            retval.ImageData = new Bitmap(@"C:\Users\jlebduska\Documents\Visual Studio 2013\Projects\SectionCheckWeb\SectionCheckWeb\Content\Images\2010_tangled_0006.jpg");
            retval.Base64String = Convert.ToBase64String(retval.BinaryData);
            return retval;
        }
        public IWebApiDocument GetWebApiDocument(ICalculationContext context)
        {
            IWebApiDocument retVal = m_resWebApiDocument.Resolve();
            string picturePath = @"C:\Users\jlebduska\Documents\Visual Studio 2013\Projects\SectionCheckWeb\SdfCalculationService\DocumentPictures";
            retVal.Pictures.Add(GetPictureWebApi(Path.Combine(picturePath, "img_1.gif"), ImageFormat.Gif, 651.0154, 415.0121, -20.00135, -20.00675));
            retVal.Pictures.Add(GetPictureWebApi(Path.Combine(picturePath, "img_2.gif"), ImageFormat.Gif, 600.9837, 85.99323, -0.9915682, 403.0013));
            retVal.Pictures.Add(GetPictureWebApi(Path.Combine(picturePath, "img_3.gif"), ImageFormat.Gif, 610.9844, 160.9973, -0.9915682, 496.9904));
            retVal.Pictures.Add(GetPictureWebApi(Path.Combine(picturePath, "img_4.gif"), ImageFormat.Gif, 486.9817, 111.9878, -0.9915682, 671.0067));
            retVal.Pictures.Add(GetPictureWebApi(Path.Combine(picturePath, "img_5.gif"), ImageFormat.Gif, 207.9828, 502.0202, -0.9915682, 777.9931));
            retVal.Pictures.Add(GetPictureWebApi(Path.Combine(picturePath, "img_6.gif"), ImageFormat.Gif, 484.9986, 146.0135, -0.9915682, 1273.99));
            retVal.Pictures.Add(GetPictureWebApi(Path.Combine(picturePath, "img_7.gif"), ImageFormat.Gif, 481.9955, 274.9932, -0.9915682, 1415.002));
            retVal.Pictures.Add(GetPictureWebApi(Path.Combine(picturePath, "img_8.gif"), ImageFormat.Gif, 436.9783, 198.0027, -0.9915682, 1697.992));
            retVal.Pictures.Add(GetPictureWebApi(Path.Combine(picturePath, "img_9.gif"), ImageFormat.Gif, 404.0016, 201.0108, -2.011467, 1890.993));
            retVal.Pictures.Add(GetPictureWebApi(Path.Combine(picturePath, "img_10.gif"), ImageFormat.Gif, 556.0232, 215.0013, -2.011467, 2086.009));
            retVal.Pictures.Add(GetPictureWebApi(Path.Combine(picturePath, "img_11.gif"), ImageFormat.Gif, 535.002, 213.9797, -2.011467, 2296.009));
            retVal.CalculateBounds();
            return retVal; 
        }
        #endregion

        #region METHODS
        string GetBaseStringFromImage(Image img, ImageFormat format)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, format);
            return Convert.ToBase64String(ms.ToArray());
        }
        WebApiPictureContext GetPictureWebApi(string filePath, ImageFormat format, double width, double height, double positionX, double positionY)
        {
            WebApiPictureContext retVal = new WebApiPictureContext();
            retVal.Base64String = GetBaseStringFromImage(new Bitmap(filePath), format);
            retVal.Location = new WebApiPictureData { BoundsHeight = height, BoundsWidth = width, BoundsLocationX = positionX, BoundsLocationY = positionY};
            return retVal;
        }
        #endregion

    }
}

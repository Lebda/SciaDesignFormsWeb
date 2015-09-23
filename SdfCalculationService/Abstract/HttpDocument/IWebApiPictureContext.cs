namespace SdfCalculationService.Abstract.HttpDocument
{
    public interface IWebApiPictureContext
    {
        string Base64String { get; set; }
        IWebApiPictureData Location { get; set; }
    }
}
namespace SdfCalculationService.Abstract.HttpDocument
{
    public interface IWebApiPictureData
    {
        double BoundsWidth { get; set; }
        double BoundsHeight { get; set; }
        double BoundsLocationX { get; set; }
        double BoundsLocationY { get; set; }
    }
}
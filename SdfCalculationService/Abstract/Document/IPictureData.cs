namespace SdfCalculationService.Abstract.Document
{
    public interface IPictureData
    {
        double BoundsWidth { get; set; }
        double BoundsHeight { get; set; }
        double BoundsLocationX { get; set; }
        double BoundsLocationY { get; set; }
    }
}
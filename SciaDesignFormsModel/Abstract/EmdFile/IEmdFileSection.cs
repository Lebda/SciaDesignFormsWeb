using SciaDesignFormsModel.Entities.Identity.EmdFileStructure;

namespace SciaDesignFormsModel.Abstract.EmdFile
{
    public interface IEmdFileSection
    {
        DbEmdSection CreateDb();
        double Position { get; set; }
        long Index { get; set; }
    }
}
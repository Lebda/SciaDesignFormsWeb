namespace SciaDesignFormsModel.Abstract.EmdFile
{
    public interface IEmdFileParser
    {
        IEmdFileStructure Parse(IEmdFileContext context);
    }
}
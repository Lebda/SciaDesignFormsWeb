namespace SciaDesignFormsModel.Abstract.EmdFile
{
    public interface IEmdFileParser
    {
        IEmdFileStrcture Parse(IEmdFileContext context);
    }
}
using System;
using System.Linq;
using SciaDesignFormsModel.Entities.Identity.EmdFileRanges;
using SciaDesignFormsModel.Entities.Identity.EmdFileStructure;

namespace SciaDesignFormsModel.ViewModels.EsaModelData
{
    static public class DbEmdExtension
    {
        static public DbEmdStructureViewModel CreateViewModel(this DbEmdStructure dbObject, long fileSize)
        {
            DbEmdStructureViewModel retVal = new DbEmdStructureViewModel();
            retVal.ID = dbObject.ID;
            retVal.Name = dbObject.Name;
            retVal.IsSelected = dbObject.IsSelected;
            retVal.Description = dbObject.Description;
            retVal.FileSize = fileSize;
            return retVal;
        }
        static public DbEmdMemberViewModel CreateViewModel(this DbEmdMember dbObject)
        {
            DbEmdMemberViewModel retVal = new DbEmdMemberViewModel();
            retVal.ID = dbObject.ID;
            retVal.Name = dbObject.Name;
            retVal.IsSelected = dbObject.IsSelected;
            return retVal;
        }
        static public DbEmdSectionViewModel CreateViewModel(this DbEmdSection dbObject)
        {
            DbEmdSectionViewModel retVal = new DbEmdSectionViewModel();
            retVal.ID = dbObject.ID;
            retVal.Index = dbObject.Index;
            retVal.Position = dbObject.Position;
            retVal.IsSelected = dbObject.IsSelected;
            return retVal;
        }
        static public DbEmdFileRangeViewModel CreateViewModel(this DbEmdFileRange dbObject, long filesSize)
        {
            DbEmdFileRangeViewModel retVal = new DbEmdFileRangeViewModel();
            retVal.EmdFilesLimit = dbObject.EmdFilesLimit;
            retVal.EmdFilesSize = filesSize;
            return retVal;
        }
        static public void UpdateDb(this DbEmdStructure dbObject, DbEmdStructureViewModel viewModel)
        {
            dbObject.IsSelected = viewModel.IsSelected;
            dbObject.Description = viewModel.Description;
        }
        static public void UpdateDb(this DbEmdMember dbObject, DbEmdMemberViewModel viewModel)
        {
            dbObject.IsSelected = viewModel.IsSelected;
        }
        static public void UpdateDb(this DbEmdSection dbObject, DbEmdSectionViewModel viewModel)
        {
            dbObject.IsSelected = viewModel.IsSelected;
        }
    }
}

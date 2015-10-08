using System;
using System.Linq;
using CommonLibrary.CollectionHelp;
using SciaDesignFormsModel.ViewModels.EsaModelData;

namespace SciaDesignFormsModel.Entities.Identity.EmdFileStructure
{
    static public class DbFileStructureExtension
    {
        static public DbEmdStructureViewModel CreateViewModel(this DbEmdStructure dbObject)
        {
            DbEmdStructureViewModel retVal = new DbEmdStructureViewModel();
            retVal.ID = dbObject.ID;
            retVal.Name = dbObject.Name;
            retVal.IsSelected = dbObject.IsSelected;
            retVal.Description = dbObject.Description;
            retVal.Members = dbObject.EmdMembers.Select(item => item.CreateViewModel()).ToCollection();
            return retVal;
        }
        static public DbEmdMemberViewModel CreateViewModel(this DbEmdMember dbObject)
        {
            DbEmdMemberViewModel retVal = new DbEmdMemberViewModel();
            retVal.Name = dbObject.Name;
            retVal.IsSelected = dbObject.IsSelected;
            retVal.Sections = dbObject.EmdSections.Select(item => item.CreateViewModel()).ToCollection();
            return retVal;
        }
        static public DbEmdSectionViewModel CreateViewModel(this DbEmdSection dbObject)
        {
            DbEmdSectionViewModel retVal = new DbEmdSectionViewModel();
            retVal.Index = dbObject.Index;
            retVal.Position = dbObject.Position;
            retVal.IsSelected = dbObject.IsSelected;
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

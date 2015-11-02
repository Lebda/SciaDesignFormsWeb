using System;
using System.Linq;
using SciaDesignFormsModel.Entities.Identity.SdfCheck;

namespace SciaDesignFormsModel.ViewModels.SdfChecks
{
    static public class DbSdfChecksExtensions
    {
        static public DbSdfCheckViewModel CreateViewModel(this DbSdfCheck dbObject)
        {
            DbSdfCheckViewModel retVal = new DbSdfCheckViewModel();
            retVal.ID = dbObject.ID.ToString();
            retVal.CheckName = dbObject.CheckName;
            retVal.Version = dbObject.Version;
            return retVal;
        }
        static public DbSdfUserCheckViewModel CreateViewModel(this DbSdfUserCheck dbObject)
        {
            DbSdfUserCheckViewModel retVal = new DbSdfUserCheckViewModel();
            retVal.ID = dbObject.ID;
            retVal.CheckName = dbObject.SdfCheck.CheckName;
            retVal.IsActive = dbObject.IsActive;
            return retVal;
        }
    }
}

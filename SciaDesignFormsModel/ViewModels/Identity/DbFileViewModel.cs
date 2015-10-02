using System;
using System.Linq;
using SciaDesignFormsModel.Entities.Identity;

namespace SciaDesignFormsModel.ViewModels.Identity
{
    public class DbFileViewModel
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string UserID { get; set; }
        public string Description { get; set; }

        //static public DbFileViewModel CreateFrom(DbFile entity)
        //{
        //    DbFileViewModel retVal = new DbFileViewModel();
        //    retVal.FileName = entity.FileName;
        //    retVal.ContentType = entity.ContentType;
        //    retVal.UserID = entity.ApplicationUserID;
        //    retVal.Description = entity.Description;
        //    return retVal;
        //}
    }
}

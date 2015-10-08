using System;
using System.Collections.Generic;
using System.Linq;
using CommonLibrary.CollectionHelp;
using SciaDesignFormsModel.Abstract.EmdFile;
using SciaDesignFormsModel.Entities.Identity.EmdFileStructure;

namespace SciaDesignFormsModel.Concrete.EmdFile
{
    class EmdFileStructure : IEmdFileStructure
    {
        public EmdFileStructure()
        {
            Members = new List<IEmdFileMember>();
            Name = String.Empty;
        }

        #region PROPERTIES
        public ICollection<IEmdFileMember> Members { get; set; }
        public string Name { get; set; }
        #endregion

        #region INTERFACE
        public DbEmdStructure CreateDb()
        {
            DbEmdStructure retVal = new DbEmdStructure();
            retVal.IsSelected = false;
            retVal.Name = Name;
            retVal.EmdMembers = Members.Select(item => item.CreateDb()).ToCollection();
            return retVal;
        }
        #endregion
    }
}

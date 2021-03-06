﻿using System;
using System.Collections.Generic;
using System.Linq;
using SciaDesignFormsModel.Abstract.EmdFile;
using SciaDesignFormsModel.Entities.Identity.EmdFileStructure;
using CommonLibrary.CollectionHelp;

namespace SciaDesignFormsModel.Concrete.EmdFile
{
    class EmdFileMember : IEmdFileMember
    {
        public EmdFileMember()
        {
            Sections = new List<IEmdFileSection>();
        }

        #region PROPERTIES
        public ICollection<IEmdFileSection> Sections { get; set; }
        public string Name { get; set; }
        #endregion

        #region INTERFACE
        public DbEmdMember CreateDb()
        {
            DbEmdMember retVal = new DbEmdMember();
            retVal.IsSelected = false;
            retVal.Name = Name;
            retVal.EmdSections = Sections.Select(item => item.CreateDb()).ToCollection();
            return retVal;
        }
        #endregion
    }
}

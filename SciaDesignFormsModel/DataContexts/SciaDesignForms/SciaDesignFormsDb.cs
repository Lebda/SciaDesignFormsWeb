using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace SciaDesignFormsModel.DataContexts.SciaDesignForms
{
    public class SciaDesignFormsDb : DbContext
    {
        public SciaDesignFormsDb() :
            base("SciaDesignFormsWeb")
        {

        }

        #region PROPERTIES
        #endregion

        #region PROTECTED
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.HasDefaultSchema("sciaDesignForms");

            base.OnModelCreating(modelBuilder);

        }
        #endregion
    }
}

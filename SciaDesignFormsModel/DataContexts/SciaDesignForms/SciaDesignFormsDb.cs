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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.HasDefaultSchema("sciaDesignForms");

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            //modelBuilder.Entity<DbFile>()
            //    .HasRequired(c => c.ApplicationUser)
            //    .WithOptional()
            //    .WillCascadeOnDelete(false);

        }
    }
}

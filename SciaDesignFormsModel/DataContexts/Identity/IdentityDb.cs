using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using SciaDesignFormsModel.Entities.Identity;
using SciaDesignFormsModel.Entities.Identity.DbEmdUserSelection;
using SciaDesignFormsModel.Entities.Identity.DbFiles;
using SciaDesignFormsModel.Intializers.Indentity;

namespace SciaDesignFormsModel.DataContexts.Identity
{
    public class IdentityDb : IdentityDbContext<ApplicationUser>
    {
        public IdentityDb()
            : base("SciaDesignFormsWeb", throwIfV1Schema: false)
        {
        }
        
        #region PROPERTIES
        public DbSet<DbEmdFile> EmdFiles { get; set; }
        public DbSet<DbEmdSelection> EmdSelections { get; set; }
        #endregion
        
        #region STATIC
        static IdentityDb()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            // I have migrations
            System.Data.Entity.Database.SetInitializer<IdentityDb>(new IdentityDbInitializer());
        }
        public static IdentityDb Create()
        {
            return new IdentityDb();
        }
        #endregion
        
        #region PROTECTED
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("identity");
            base.OnModelCreating(modelBuilder);
                      
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            // ONE-TO-MANY ApplicationUser(IdentityUser) & DbEmdFile
            modelBuilder.Entity<DbEmdFile>()
                        .HasRequired(c => c.ApplicationUser)
                        .WithMany()
                        .WillCascadeOnDelete(false);
            //modelBuilder.Entity<ApplicationUser>()
            //            .HasMany<DbEmdFile>(s => s.EmdFiles)
            //            .WithRequired(s => s.ApplicationUser)
            //            .HasForeignKey(s => s.ApplicationUserID);
            //modelBuilder.Entity<DbEmdFile>()
            //            .HasRequired<ApplicationUser>(s => s.ApplicationUser)
            //            .WithMany(s => s.EmdFiles)
            //            .HasForeignKey(s => s.ApplicationUserID);


            // ONE-TO-ONE ApplicationUser(IdentityUser) & DbEmdSelection
            modelBuilder.Entity<DbEmdSelection>()
                .HasKey(t => t.ID)
                .HasRequired(t => t.ApplicationUser)
                .WithRequiredDependent();
           
            // ONE-TO-ONE DbEmdSelection & DbEmdFile
            modelBuilder.Entity<DbEmdFile>()
                .HasOptional(t => t.EmdSelection)
                .WithOptionalPrincipal(t => t.EmdFile);         
        }
        #endregion
    }
}
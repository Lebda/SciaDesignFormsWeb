using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using SciaDesignFormsModel.Entities.Identity;
using SciaDesignFormsModel.Entities.Identity.DbFiles;
using SciaDesignFormsModel.Entities.Identity.EmdFileRanges;
using SciaDesignFormsModel.Entities.Identity.EmdFileStructure;
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
        public DbSet<DbEmdStructure> Structures { get; set; }
        public DbSet<DbEmdMember> Members { get; set; }
        public DbSet<DbEmdSection> Sections { get; set; }
        public DbSet<DbEmdFileRange> FileRanges { get; set; }
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
            
            ////***********ApplicationUser**********  
            // ONE-TO-MANY --> DbEmdFile
            modelBuilder.Entity<DbEmdFile>()
                        .HasRequired(c => c.ApplicationUser)
                        .WithMany()
                        .WillCascadeOnDelete(false);
            // ONE-TO-ONE --> DbEmdFileRange
            modelBuilder.Entity<DbEmdFileRange>()
                        .HasRequired(t => t.ApplicationUser)
                        .WithOptional();
            ////***********ApplicationUser********** 
            
            
            // ONE-TO-ONE DbEmdStructure & DbEmdFile
            modelBuilder.Entity<DbEmdFile>()
                        .HasRequired(t => t.Structure)
                        .WithRequiredPrincipal(t => t.EmdFile);
            
            // ONE-TO-MANY DbEmdStructure & DbEmdMember
            modelBuilder.Entity<DbEmdStructure>()
                        .HasMany<DbEmdMember>(t => t.EmdMembers)
                        .WithRequired(t => t.EmdStructure)
                        .HasForeignKey(t => t.EmdStructureID);
            
            // ONE-TO-MANY DbEmdMember & DbEmdSection
            modelBuilder.Entity<DbEmdMember>()
                        .HasMany<DbEmdSection>(t => t.EmdSections)
                        .WithRequired(t => t.Member)
                        .HasForeignKey(t => t.MemberID);
        }
        #endregion
    }
}
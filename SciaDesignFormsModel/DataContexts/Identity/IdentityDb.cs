using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using SciaDesignFormsModel.Entities.Identity;
using SciaDesignFormsModel.Intializers.Indentity;

namespace SciaDesignFormsModel.DataContexts.Identity
{
    public class IdentityDb : IdentityDbContext<ApplicationUser>
    {
        public IdentityDb()
            : base("SciaDesignFormsWeb", throwIfV1Schema: false)
        {
        }
        public DbSet<DbFile> DbFiles { get; set; }
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
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("identity");
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<DbFile>()
            //            .HasRequired(c => c.ApplicationUser)
            //            .WithOptional()
            //            .WillCascadeOnDelete(false);

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}
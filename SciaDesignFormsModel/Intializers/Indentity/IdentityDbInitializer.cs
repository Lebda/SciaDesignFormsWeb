﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using SciaDesignFormsModel.DataContexts.Identity;
using SciaDesignFormsModel.Entities.Identity;
using SciaDesignFormsModel.Entities.Identity.EmdFileRanges;
using SciaDesignFormsModel.Entities.Identity.SdfCheck;
using SciaDesignFormsModel.IndentityConfig;

namespace SciaDesignFormsModel.Intializers.Indentity
{
    public class IdentityDbInitializer : DropCreateDatabaseIfModelChanges<IdentityDb> //DropCreateDatabaseIfModelChanges DropCreateDatabaseAlways CreateDatabaseIfNotExists
    {
        protected override void Seed(IdentityDb context)
        {
            InitializeIdentityForEF();
            CreateFileRanges(context);
            CreateSdfChecks(context);
            base.Seed(context);
        }
        public static void CreateSdfChecks(IdentityDb context)
        {
            var sdfChecks = new List<DbSdfCheck>
            {
                new DbSdfCheck { CheckName = "Check response - response", Version = "0.0.1" },
                new DbSdfCheck { CheckName = "Check response - diagram", Version = "0.0.1" },
                new DbSdfCheck { CheckName = "Check shear", Version = "0.0.1" },
                new DbSdfCheck { CheckName = "Check torsion", Version = "0.0.1" }
            };
            sdfChecks.ForEach(s => context.SdfChecks.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();
            IOwinContext owin = HttpContext.Current.GetOwinContext();
            var userManager = owin.GetUserManager<ApplicationUserManager>();
            if (userManager == null)
            {
                return;
            }
            ApplicationUser user = userManager.FindByName("admin@example.com");
            var userCheckFirst = new DbSdfUserCheck { ApplicationUserID = user.Id, IsActive = true, SdfCheckID = context.SdfChecks.First().ID };
            userCheckFirst.ApplicationUserID = user.Id;
            context.SdfUserChecks.Add(userCheckFirst);
            context.SaveChanges();
            var userCheckLast = new DbSdfUserCheck { ApplicationUserID = user.Id, IsActive = true, SdfCheckID = context.SdfChecks.ToList().Last().ID };
            userCheckLast.ApplicationUserID = user.Id;
            context.SdfUserChecks.Add(userCheckLast);
            context.SaveChanges();
        }
        public static void CreateFileRanges(IdentityDb context)
        {
            IOwinContext owin = HttpContext.Current.GetOwinContext();
            var userManager = owin.GetUserManager<ApplicationUserManager>();
            if (userManager == null)
            {
                return;
            }
            foreach (var item in userManager.Users)
            {
                context.FileRanges.Add(new DbEmdFileRange { ApplicationUser = item });  
            }
            context.SaveChanges();
        }
        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        public static void InitializeIdentityForEF()
        {
            if (HttpContext.Current == null)
            {
                return;
            }
            IOwinContext owin = HttpContext.Current.GetOwinContext();
            if (owin == null)
            {
                return;
            }
            var userManager = owin.GetUserManager<ApplicationUserManager>();
            if (userManager == null)
            {
                return;
            }
            var roleManager = owin.Get<ApplicationRoleManager>();
            if (roleManager == null)
            {
                return;
            }
            var role = roleManager.FindByName(RoleNames.c_architectRoleName);
            if (role != null)
            {
                return;
            }
            CreateRole(roleManager, RoleNames.c_userRoleName, "Website user !");
            CreateRole(roleManager, RoleNames.c_dataMakerRoleName, "Website data creator !");
            var admin = CreateRole(roleManager, RoleNames.c_adminRoleName, "Can modificate data !");
            var architectRole = CreateRole(roleManager, RoleNames.c_architectRoleName, "All privileges !");
            AddUser2Role(userManager, architectRole, "lebsoft@seznam.cz", "Lebda@19810916");
            AddUser2Role(userManager, admin, "admin@example.com", "Admin@123456");
        }
        public static ApplicationRole CreateRole(ApplicationRoleManager manager, string roleName, string description)
        {
            var role = manager.FindByName(roleName);
            if (role == null)
            {
                role = new ApplicationRole(roleName);
                role.Description = description;
                manager.Create(role);
            }
            return role;
        }
        public static void AddUser2Role(ApplicationUserManager manager, ApplicationRole role, string name, string password)
        {
            ApplicationUser user = manager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name };
                manager.Create(user, password);
                manager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = manager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                manager.AddToRole(user.Id, role.Name);
            }
        }
    }
}
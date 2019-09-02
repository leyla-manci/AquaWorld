using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AquaWorld.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            // Initialize default identity roles
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);
            // RoleTypes is a class containing constant string values for different roles
            List<IdentityRole> identityRoles = new List<IdentityRole>();
            identityRoles.Add(new IdentityRole() { Name = "Admin" });
            identityRoles.Add(new IdentityRole() { Name = "Secretary" });
            identityRoles.Add(new IdentityRole() { Name = "User" });

            foreach (IdentityRole role in identityRoles)
            {
                manager.Create(role);
            }

            // Initialize default user
            var store1 = new UserStore<IdentityUser>(context);
            var manager1 = new UserManager<IdentityUser>(store1);
            IdentityUser admin = new IdentityUser();
            admin.Email = "admin@admin.com";
            admin.UserName = "admin";

            manager1.Create(admin, "1Admin!");
            manager1.AddToRole(admin.Id, "Admin");

            // Add code to initialize context tables

            base.Seed(context);
        }
    }
}
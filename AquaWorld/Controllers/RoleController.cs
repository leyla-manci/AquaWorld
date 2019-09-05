using AquaWorld.Identity;
using AquaWorld.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AquaWorld.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<IdentityUser> userManager;
        public RoleController()
        {
            var roleStore = new RoleStore<IdentityRole>(new IdentityDataContext());
            roleManager = new RoleManager<IdentityRole>(roleStore);

            var userStore = new UserStore<IdentityUser>(new IdentityDataContext());
            userManager = new UserManager<IdentityUser>(userStore);

        }

        // GET: Role
        public ActionResult Index()
        {
            return View(roleManager.Roles);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string roleName)
        {

            if (ModelState.IsValid)
            {
                if (!this.roleExist(roleName))
                {
                    var result = roleManager.Create(new IdentityRole(roleName));
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item);
                        }

                    }

                }
                else
                {
                    ModelState.AddModelError("", "bu isimde rol kaydı mevcut");
                }

            }

            return View("Create", null, roleName);

        }
        [HttpPost]
        public ActionResult Delete(string Id)
        {
            var role = roleManager.FindById(Id);
            if (role != null)
            {
                var result = roleManager.Delete(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    return View("Error", result.Errors);
                }

            }
            else
            {
                return View("Error", new string[] { "Rol Bulunamadı" });
            }


        }

        [HttpGet]
        public ActionResult Edit(string roleId)
        {
            var role = roleManager.FindById(roleId);

            var members = new List<IdentityUser>();
            var nonmembers = new List<IdentityUser>();
            foreach (var user in userManager.Users.ToList())
            {
                var list = userManager.IsInRole(user.Id, role.Name) ? members : nonmembers;
                list.Add(user);

            }
            return View(new RoleUsersModel()
            {
                identityRole = role,
                members = members,
                nonMembers = nonmembers
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UpdatedRoleUsersModel model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (var item in model.IdListtoAdd ?? new string[] { })
                {
                    result = userManager.AddToRole(item,model.RoleName);
                    if (!result.Succeeded)
                    {
                        return View("Error",result.Errors);

                    }

                }
                foreach (var item in model.IdListtoDelete ?? new string[] { })
                {
                    result = userManager.RemoveFromRole(item,model.RoleName);
                    if (!result.Succeeded)
                    {
                        return View("Error", result.Errors);

                    }
                }
                return RedirectToAction("Index");
            }
            return View("Error",new string[] { "bir şeyler ters gitti!"});

        }

            private bool roleExist(string roleName)
        {
            bool isExist = false;
            if (roleManager.FindByName(roleName) != null)
            {
                isExist = true;

            }

            return isExist;
        }

    }
}
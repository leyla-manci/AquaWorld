using AquaWorld.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AquaWorld.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private UserManager<IdentityUser> userManager;

        public AdminController()
        {
            var userStore = new UserStore<IdentityUser>(new IdentityDataContext());
            userManager = new UserManager<IdentityUser>(userStore);
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(userManager.Users);
        }
    }
}
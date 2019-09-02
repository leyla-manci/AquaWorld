using AquaWorld.Identity;
using AquaWorld.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AquaWorld.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        private UserManager<IdentityUser> userManager;

        public AccountController()
        {
            var userStore = new UserStore<IdentityUser>(new IdentityDataContext());
            userManager = new UserManager<IdentityUser>(userStore);
        }


        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel loginmodel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Find(loginmodel.UserName, loginmodel.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Yanlış Kullanıcı Adı veya Parola");

                }
                else
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identity = userManager.CreateIdentity(user, "ApplicationCookie");

                    var authProperties = new AuthenticationProperties()
                    {
                        IsPersistent = loginmodel.IsRememberMe

                    };
                    authManager.SignOut();
                    authManager.SignIn(authProperties, identity);
                    return Redirect(string.IsNullOrEmpty(returnUrl) ? "~/" : returnUrl);
                }

            }
            ViewBag.ReturnUrl = returnUrl;
            return View(loginmodel);
        }

       
        public ActionResult Logout()
        {

            var authManager = HttpContext.GetOwinContext().Authentication;

            authManager.SignOut();


            return RedirectToAction("Index", "Home");

        }


        [AllowAnonymous]
        public ActionResult Register()
        {

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser();
                user.UserName = userModel.UserName;
                user.Email = userModel.Email;

                var result = userManager.Create(user, userModel.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }

                }
            }


            return View(userModel);
        }


    }
}
using AquaWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AquaWorld.Controllers
{
    public class HomeController : Controller
    {


        private AquaWorldContext dbContext = new AquaWorldContext();
        // GET: Home
        public ActionResult Index()
        {
            return View(dbContext.fishes.ToList());
        }
    }
}
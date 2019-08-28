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
            var fishModel = dbContext.fishes
                .Select(i => new FishModel()
                { FishId = i.FishId ,Name = i.Name ,
                    ShortDesc = i.ShortDesc.Length >40 ? i.ShortDesc.Substring(0,40) + " ... " : i.ShortDesc,
                    FishImage = i.FishImage
                }) ;
            return View(fishModel.ToList());
        }
    }
}
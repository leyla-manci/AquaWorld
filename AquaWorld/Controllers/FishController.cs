using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AquaWorld.Models;

namespace AquaWorld.Controllers
{
    public class FishController : Controller
    {
        private AquaWorldContext db = new AquaWorldContext();

        // GET: Fish
        public ActionResult Index()
        {
            var fishes = db.fishes.Include(f => f.category);
            return View(fishes.ToList());
        }

        // GET: Fish/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Fish fish = db.fishes.Find(id);
            var fishes = db.fishes.Include(f => f.category).AsQueryable().Where(i=> i.FishId == id);
            Fish fish = (Fish)fishes.First();
            if (fish == null)
            {
                return HttpNotFound();
            }
            return View(fish);
        }

        // GET: Fish/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.categories, "CategoryId", "ShortDesc");
            return View();
        }

        // POST: Fish/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,ShortDesc,LongDesc,FishImage,CategoryId")] Fish fish)
        {
            if (ModelState.IsValid)
            {
                db.fishes.Add(fish);
                db.SaveChanges();
                TempData["NewFish"] = fish;
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.categories, "CategoryId", "ShortDesc", fish.CategoryId);
            return View(fish);
        }

        // GET: Fish/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fish fish = db.fishes.Find(id);
            if (fish == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.categories, "CategoryId", "ShortDesc", fish.CategoryId);
            return View(fish);
        }

        // POST: Fish/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FishId,Name,ShortDesc,LongDesc,FishImage,CategoryId")] Fish fish)
        {
            if (ModelState.IsValid)
            {

                //db.Entry(fish).State = EntityState.Modified;
                Fish fish1 = db.fishes.Find(fish.FishId);
                if (fish1 != null)
                {
                    fish1.Name = fish.Name;
                    fish1.ShortDesc = fish.ShortDesc;
                    fish1.LongDesc = fish.LongDesc;
                    fish1.FishImage = fish.FishImage;
                    fish1.CategoryId = fish.CategoryId;
                    db.SaveChanges();
                    TempData["Fish"] = fish;
                    return RedirectToAction("Index");

                }
             
            }
            ViewBag.CategoryId = new SelectList(db.categories, "CategoryId", "ShortDesc", fish.CategoryId);
            return View(fish);
        }

        // GET: Fish/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fish fish = db.fishes.Find(id);
            if (fish == null)
            {
                return HttpNotFound();
            }
            return View(fish);
        }

        // POST: Fish/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fish fish = db.fishes.Find(id);
            db.fishes.Remove(fish);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

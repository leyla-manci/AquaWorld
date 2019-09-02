using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AquaWorld.Models;

namespace AquaWorld.Controllers
{
    public class FishWsrController : ApiController
    {
        private AquaWorldContext db = new AquaWorldContext();

        // GET: api/FishWsr
        public IQueryable<Fish> Getfishes()
        {
            return db.fishes;
        }

        // GET: api/FishWsr/5
        
        [ResponseType(typeof(Fish))]
        public IHttpActionResult GetFish(int id)
        {
            Fish fish = db.fishes.Find(id);
            if (fish == null)
            {
                return NotFound();
            }

            return Ok(fish);
        }

        // PUT: api/FishWsr/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFish(int id, Fish fish)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fish.FishId)
            {
                return BadRequest();
            }

            db.Entry(fish).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FishExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/FishWsr
        [ResponseType(typeof(Fish))]
        public IHttpActionResult PostFish(Fish fish)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.fishes.Add(fish);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fish.FishId }, fish);
        }

        // DELETE: api/FishWsr/5
        [ResponseType(typeof(Fish))]
        public IHttpActionResult DeleteFish(int id)
        {
            Fish fish = db.fishes.Find(id);
            if (fish == null)
            {
                return NotFound();
            }

            db.fishes.Remove(fish);
            db.SaveChanges();

            return Ok(fish);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

      
     
        private bool FishExists(int id)
        {
            return db.fishes.Count(e => e.FishId == id) > 0;
        }
    }
}
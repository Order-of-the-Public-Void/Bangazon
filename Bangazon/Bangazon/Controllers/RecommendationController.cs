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
using Bangazon.Models;

namespace Bangazon.Controllers
{
    public class RecommendationController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Recommendation
        public IQueryable<Recommendation> GetRecommendations()
        {
            return db.Recommendations;
        }

        // GET: api/Recommendation/5
        [ResponseType(typeof(Recommendation))]
        public IHttpActionResult GetRecommendation(int id)
        {
            Recommendation recommendation = db.Recommendations.Find(id);
            if (recommendation == null)
            {
                return NotFound();
            }

            return Ok(recommendation);
        }

        // PUT: api/Recommendation/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecommendation(int id, Recommendation recommendation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recommendation.RecommendationId)
            {
                return BadRequest();
            }

            db.Entry(recommendation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecommendationExists(id))
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

        // POST: api/Recommendation
        [ResponseType(typeof(Recommendation))]
        public IHttpActionResult PostRecommendation(Recommendation recommendation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Recommendations.Add(recommendation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recommendation.RecommendationId }, recommendation);
        }

        // DELETE: api/Recommendation/5
        [ResponseType(typeof(Recommendation))]
        public IHttpActionResult DeleteRecommendation(int id)
        {
            Recommendation recommendation = db.Recommendations.Find(id);
            if (recommendation == null)
            {
                return NotFound();
            }

            db.Recommendations.Remove(recommendation);
            db.SaveChanges();

            return Ok(recommendation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecommendationExists(int id)
        {
            return db.Recommendations.Count(e => e.RecommendationId == id) > 0;
        }
    }
}
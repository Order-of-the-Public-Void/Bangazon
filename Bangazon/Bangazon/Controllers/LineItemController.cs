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
    public class LineItemController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/LineItem
        public IQueryable<LineItem> GetLineItems()
        {
            return db.LineItems;
        }

        // GET: api/LineItem/5
        [ResponseType(typeof(LineItem))]
        public IHttpActionResult GetLineItem(int id)
        {
            LineItem lineItem = db.LineItems.Find(id);
            if (lineItem == null)
            {
                return NotFound();
            }

            return Ok(lineItem);
        }

        // PUT: api/LineItem/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLineItem(int id, LineItem lineItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lineItem.LineItemId)
            {
                return BadRequest();
            }

            db.Entry(lineItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineItemExists(id))
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

        // POST: api/LineItem
        [ResponseType(typeof(LineItem))]
        public IHttpActionResult PostLineItem(LineItem lineItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LineItems.Add(lineItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lineItem.LineItemId }, lineItem);
        }

        // DELETE: api/LineItem/5
        [ResponseType(typeof(LineItem))]
        public IHttpActionResult DeleteLineItem(int id)
        {
            LineItem lineItem = db.LineItems.Find(id);
            if (lineItem == null)
            {
                return NotFound();
            }

            db.LineItems.Remove(lineItem);
            db.SaveChanges();

            return Ok(lineItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LineItemExists(int id)
        {
            return db.LineItems.Count(e => e.LineItemId == id) > 0;
        }
    }
}
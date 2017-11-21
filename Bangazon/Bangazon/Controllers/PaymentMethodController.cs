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
    public class PaymentMethodController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/PaymentMethod
        public IQueryable<PaymentMethod> GetPaymentMethods()
        {
            return db.PaymentMethods;
        }

        // GET: api/PaymentMethod/5
        [ResponseType(typeof(PaymentMethod))]
        public IHttpActionResult GetPaymentMethod(int id)
        {
            PaymentMethod paymentMethod = db.PaymentMethods.Find(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }

            return Ok(paymentMethod);
        }

        // PUT: api/PaymentMethod/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPaymentMethod(int id, PaymentMethod paymentMethod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentMethod.PaymentMethodId)
            {
                return BadRequest();
            }

            db.Entry(paymentMethod).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentMethodExists(id))
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

        // POST: api/PaymentMethod
        [ResponseType(typeof(PaymentMethod))]
        public IHttpActionResult PostPaymentMethod(PaymentMethod paymentMethod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PaymentMethods.Add(paymentMethod);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = paymentMethod.PaymentMethodId }, paymentMethod);
        }

        // DELETE: api/PaymentMethod/5
        [ResponseType(typeof(PaymentMethod))]
        public IHttpActionResult DeletePaymentMethod(int id)
        {
            PaymentMethod paymentMethod = db.PaymentMethods.Find(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }

            db.PaymentMethods.Remove(paymentMethod);
            db.SaveChanges();

            return Ok(paymentMethod);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaymentMethodExists(int id)
        {
            return db.PaymentMethods.Count(e => e.PaymentMethodId == id) > 0;
        }
    }
}
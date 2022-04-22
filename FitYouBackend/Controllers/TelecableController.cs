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
using FitYouBackend.Models;

namespace FitYouBackend.Controllers
{
    public class TelecableController : ApiController
    {
        private FityouContext db = new FityouContext();

        // GET: api/GetTelecables
        [Route("api/GetTelecables")]
        [HttpGet]
        public IEnumerable<Telecable> GetTelecables()
        {
            return db.Telecables.ToList();
        }

        // GET: api/GetTelecableById/5
        [ResponseType(typeof(Telecable))]
        [Route("api/GetTelecableById/{id}")]
        [HttpGet]
        public IHttpActionResult GetTelecable(int id)
        {
            Telecable telecable = db.Telecables.Find(id);
            if (telecable == null)
            {
                return NotFound();
            }

            return Ok(telecable);
        }

        // PUT: api/PutTelecable/5
        [ResponseType(typeof(void))]
        [Route("api/PutTelecable/{id}")]
        [HttpPut]
        public IHttpActionResult PutTelecable(int id,[FromBody] Telecable telecable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != telecable.Id)
            {
                return BadRequest();
            }

            db.Entry(telecable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelecableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Telecable updated successfully.");
        }

        // POST: api/PostTelecable
        [ResponseType(typeof(Telecable))]
        [Route("api/PostTelecable")]
        [HttpPost]
        public IHttpActionResult PostTelecable([FromBody]Telecable telecable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Telecables.Add(telecable);
            db.SaveChanges();

            return Ok("Telecable created successfully.");
        }

        // DELETE: api/DeleteTelecable/5
        [ResponseType(typeof(Telecable))]
        [Route("api/DeleteTelecable/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteTelecable(int id)
        {
            Telecable telecable = db.Telecables.Find(id);
            if (telecable == null)
            {
                return NotFound();
            }

            db.Telecables.Remove(telecable);
            db.SaveChanges();

            return Ok("Telecable deleted successfully.");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TelecableExists(int id)
        {
            return db.Telecables.Count(e => e.Id == id) > 0;
        }
    }
}
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
    public class TelephoneController : ApiController
    {
        private FityouContext db = new FityouContext();

        // GET: api/GetTelephones
        [Route("api/GetTelephones")]
        [HttpGet]
        public IEnumerable<Telephone> GetTelephones()
        {
            return db.Telephones.ToList();
        }

        // GET: api/GetTelephoneById/5
        [ResponseType(typeof(Telephone))]
        [Route("api/GetTelephoneById/{id}")]
        [HttpGet]
        public IHttpActionResult GetTelephone(int id)
        {
            Telephone telephone = db.Telephones.Find(id);
            if (telephone == null)
            {
                return NotFound();
            }

            return Ok(telephone);
        }

        // PUT: api/PutTelephone/5
        [ResponseType(typeof(void))]
        [Route("api/PutTelephone/{id}")]
        [HttpPut]
        public IHttpActionResult PutTelephone(int id, [FromBody] Telephone telephone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != telephone.Id)
            {
                return BadRequest();
            }

            db.Entry(telephone).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelephoneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Telephone updated successfully.");
        }

        // POST: api/PostTelephone
        [ResponseType(typeof(Telephone))]
        [Route("api/PostTelephone")]
        [HttpPost]
        public IHttpActionResult PostTelephone([FromBody]Telephone telephone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Telephones.Add(telephone);
            db.SaveChanges();

            return Ok("Telephone created successfully.");
        }

        // DELETE: api/DeleteTelephone/5
        [ResponseType(typeof(Telephone))]
        [Route("api/DeleteTelephone/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteTelephone(int id)
        {
            Telephone telephone = db.Telephones.Find(id);
            if (telephone == null)
            {
                return NotFound();
            }

            db.Telephones.Remove(telephone);
            db.SaveChanges();

            return Ok("Telephone deleted successfully.");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TelephoneExists(int id)
        {
            return db.Telephones.Count(e => e.Id == id) > 0;
        }
    }
}
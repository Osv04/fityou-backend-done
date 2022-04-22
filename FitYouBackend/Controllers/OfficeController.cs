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
    public class OfficeController : ApiController
    {
        private FityouContext db = new FityouContext();

        // GET: api/GetOffices
        [Route("api/GetOffices")]
        [HttpGet]
        public IEnumerable<Office> GetOffices()
        {
            return db.Offices.ToList();
        }

        // GET: api/GetOfficeById/5
        [ResponseType(typeof(Office))]
        [Route("api/GetOfficeById/{id}")]
        [HttpGet]
        public IHttpActionResult GetOffice(int id)
        {
            Office office = db.Offices.Find(id);
            if (office == null)
            {
                return NotFound();
            }

            return Ok(office);
        }

        // PUT: api/PutOffice/5
        [ResponseType(typeof(void))]
        [Route("api/PutOffice/{id}")]
        [HttpPut]
        public IHttpActionResult PutOffice(int id, [FromBody] Office office)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != office.Id)
            {
                return BadRequest();
            }

            db.Entry(office).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Office updated successfully.");
        }

        // POST: api/PostOffice
        [ResponseType(typeof(Office))]
        [Route("api/PostOffice")]
        [HttpPost]
        public IHttpActionResult PostOffice([FromBody] Office office)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Offices.Add(office);
            db.SaveChanges();

            return Ok("Office created successfully.");
        }

        // DELETE: api/DeleteOffice/5
        [ResponseType(typeof(Office))]
        [Route("api/DeleteOffice/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteOffice(int id)
        {
            Office office = db.Offices.Find(id);
            if (office == null)
            {
                return NotFound();
            }

            db.Offices.Remove(office);
            db.SaveChanges();

            return Ok("Office deleted successfully.");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OfficeExists(int id)
        {
            return db.Offices.Count(e => e.Id == id) > 0;
        }
    }
}
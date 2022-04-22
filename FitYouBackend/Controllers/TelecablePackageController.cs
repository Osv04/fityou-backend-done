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
    public class TelecablePackageController : ApiController
    {
        private FityouContext db = new FityouContext();

        // GET: api/GetTelecablePackages
        [Route("api/GetTelecablePackages")]
        [HttpGet]
        public IEnumerable<TelecablePackage> GetTelecablePackages()
        {
            return db.TelecablePackages.ToList();
        }

        // GET: api/GetTelecablePackage/5
        [ResponseType(typeof(TelecablePackage))]
        [Route("api/GetTelecablePackageById/{id}")]
        [HttpGet]
        public IHttpActionResult GetTelecablePackage(int id)
        {
            TelecablePackage telecablePackage = db.TelecablePackages.Find(id);
            if (telecablePackage == null)
            {
                return NotFound();
            }

            return Ok(telecablePackage);
        }

        // PUT: api/PutTelecablePackage/5
        [ResponseType(typeof(void))]
        [Route("api/PutTelecablePackage/{id}")]
        [HttpPut]
        public IHttpActionResult PutTelecablePackage(int id,[FromBody] TelecablePackage telecablePackage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != telecablePackage.Id)
            {
                return BadRequest();
            }

            db.Entry(telecablePackage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelecablePackageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Telecable-Package updated successfully.");
        }

        // POST: api/PostTelecablePackage
        [ResponseType(typeof(TelecablePackage))]
        [Route("api/PostTelecablePackage")]
        [HttpPost]
        public IHttpActionResult PostTelecablePackage([FromBody]TelecablePackage telecablePackage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TelecablePackages.Add(telecablePackage);
            db.SaveChanges();

            return Ok("Telecable-Package created successfully.");
        }

        // DELETE: api/DeleteTelecablePackage/5
        [ResponseType(typeof(TelecablePackage))]
        [Route("api/DeleteTelecablePackage/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteTelecablePackage(int id)
        {
            TelecablePackage telecablePackage = db.TelecablePackages.Find(id);
            if (telecablePackage == null)
            {
                return NotFound();
            }

            db.TelecablePackages.Remove(telecablePackage);
            db.SaveChanges();

            return Ok("Telecable-Package deleted successfully.");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TelecablePackageExists(int id)
        {
            return db.TelecablePackages.Count(e => e.Id == id) > 0;
        }
    }
}
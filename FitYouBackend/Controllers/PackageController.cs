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
    public class PackageController : ApiController
    {
        private FityouContext db = new FityouContext();

        // GET: api/GetPackages
        [Route("api/GetPackages")]
        [HttpGet]
        public IEnumerable<Package> GetPackages()
        {
            return db.Packages.ToList();
        }

        // GET: api/GetPackageById/5
        [ResponseType(typeof(Package))]
        [Route("api/GetPackageById/{id}")]
        [HttpGet]
        public IHttpActionResult GetPackage(int id)
        {
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return NotFound();
            }

            return Ok(package);
        }

        // PUT: api/PutPackage/5
        [ResponseType(typeof(void))]
        [Route("api/PutPackage/{id}")]
        [HttpPut]
        public IHttpActionResult PutPackage(int id,[FromBody] Package package)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != package.Id)
            {
                return BadRequest();
            }

            db.Entry(package).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Package updated successfully.");
        }

        // POST: api/PostPackage
        [ResponseType(typeof(Package))]
        [Route("api/PostPackage")]
        [HttpPost]
        public IHttpActionResult PostPackage([FromBody] Package package)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Packages.Add(package);
            db.SaveChanges();

            return Ok("Package created successfully.");
        }

        // DELETE: api/DeletePackage/5
        [ResponseType(typeof(Package))]
        [Route("api/DeletePackage/{id}")]
        [HttpDelete]
        public IHttpActionResult DeletePackage(int id)
        {
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return NotFound();
            }

            db.Packages.Remove(package);
            db.SaveChanges();

            return Ok("Package deleted successfully.");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PackageExists(int id)
        {
            return db.Packages.Count(e => e.Id == id) > 0;
        }
    }
}
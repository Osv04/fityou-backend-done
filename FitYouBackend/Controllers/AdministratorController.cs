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
    public class AdministratorController : ApiController
    {
        private FityouContext db = new FityouContext();

        // GET: api/getAdministrators
        [Route("api/getAdministrators")]
        [HttpGet]
        public IEnumerable<Administrator> GetAdministrators()
        {
            return db.Administrators.ToList();
        }

        // GET: api/getAdministratorById/5
        [Route("api/getAdministratorById/{id}")]
        [ResponseType(typeof(Administrator))]
        [HttpGet]
        public IHttpActionResult GetAdministrator(int id)
        {
            Administrator administrator = db.Administrators.Find(id);
            if (administrator == null)
            {
                return NotFound();
            }

            return Ok(administrator);
        }

        // PUT: api/putAdministrator/5
        [ResponseType(typeof(void))]
        [Route("api/putAdministrator/{id}")]
        [HttpPut]
        public IHttpActionResult PutAdministrator(int id, [FromBody] Administrator administrator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != administrator.Id)
            {
                return BadRequest();
            }

            db.Entry(administrator).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministratorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Administrator updated successfully.");
            //return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/postAdministrator
        [ResponseType(typeof(Administrator))]
        [Route("api/postAdministrator")]
        [HttpPost]
        public IHttpActionResult PostAdministrator([FromBody] Administrator administrator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Administrators.Add(administrator);
            db.SaveChanges();

            return Ok("Administrator created successfully.");
            //return CreatedAtRoute("api/postAdministrator", new { id = administrator.Id }, administrator);
        }

        // DELETE: api/deleteAdministrator/5
        [ResponseType(typeof(Administrator))]
        [Route("api/deleteAdministrator/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteAdministrator(int id)
        {
            Administrator administrator = db.Administrators.Find(id);
            if (administrator == null)
            {
                return NotFound();
            }

            db.Administrators.Remove(administrator);
            db.SaveChanges();
            
            return Ok("Administrator deleted successfully.");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdministratorExists(int id)
        {
            return db.Administrators.Count(e => e.Id == id) > 0;
        }
    }
}
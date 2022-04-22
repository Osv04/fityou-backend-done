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
    public class InternetController : ApiController
    {
        private FityouContext db = new FityouContext();

        // GET: api/GetInternets
        [Route("api/GetInternets")]
        [HttpGet]
        public IEnumerable<Internet> GetInternets()
        {
            return db.Internets.ToList();
        }

        // GET: api/GetInternetById/5
        [ResponseType(typeof(Internet))]
        [Route("api/GetInternetById/{id}")]
        [HttpGet]
        public IHttpActionResult GetInternet(int id)
        {
            Internet internet = db.Internets.Find(id);
            if (internet == null)
            {
                return NotFound();
            }

            //internet.Plan = db.Plans.Find(internet.PlanId);

            return Ok(internet);
        }

        // PUT: api/PutInternet/5
        [ResponseType(typeof(void))]
        [Route("api/PutInternet/{id}")]
        [HttpPut]
        public IHttpActionResult PutInternet(int id, [FromBody] Internet internet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != internet.Id)
            {
                return BadRequest();
            }

            db.Entry(internet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InternetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Internet updated successfully.");
        }

        // POST: api/postInternet
        [ResponseType(typeof(Internet))]
        [Route("api/PostInternet")]
        [HttpPost]
        public IHttpActionResult PostInternet([FromBody] Internet internet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Internets.Add(internet);
            db.SaveChanges();

            return Ok("Internet created successfully.");
        }

        // DELETE: api/DeleteInternet/5
        [ResponseType(typeof(Internet))]
        [Route("api/DeleteInternet/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteInternet(int id)
        {
            Internet internet = db.Internets.Find(id);
            if (internet == null)
            {
                return NotFound();
            }

            db.Internets.Remove(internet);
            db.SaveChanges();

            return Ok("Internet deleted successfully.");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InternetExists(int id)
        {
            return db.Internets.Count(e => e.Id == id) > 0;
        }
    }
}
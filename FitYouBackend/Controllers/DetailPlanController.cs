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
    public class DetailPlanController : ApiController
    {
        private FityouContext db = new FityouContext();

        // GET: api/getDetailPlans
        [Route("api/getDetailPlans")]
        [HttpGet]
        public IEnumerable<DetailPlan> GetDetailPlans()
        {
            return db.DetailPlans.ToList();
        }

        // GET: api/getDetailPlanById/5
        [ResponseType(typeof(DetailPlan))]
        [Route("api/getDetailPlanById/{id}")]
        [HttpGet]
        public IHttpActionResult GetDetailPlan(int id)
        {
            DetailPlan detailPlan = db.DetailPlans.Find(id);
            if (detailPlan == null)
            {
                return NotFound();
            }

            return Ok(detailPlan);
        }

        // PUT: api/putDetailPlan/5
        [ResponseType(typeof(void))]
        [Route("api/putDetailPlan/{id}")]
        [HttpPut]
        public IHttpActionResult PutDetailPlan(int id, [FromBody] DetailPlan detailPlan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detailPlan.Id)
            {
                return BadRequest();
            }

            db.Entry(detailPlan).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailPlanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("DetailPlan updated successfully.");
        }

        // POST: api/postDetailPlan
        [ResponseType(typeof(DetailPlan))]
        [Route("api/postDetailPlan")]
        [HttpPost]
        public IHttpActionResult PostDetailPlan([FromBody] DetailPlan detailPlan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DetailPlans.Add(detailPlan);
            db.SaveChanges();

            return Ok("DetailPlan created successfully.");
        }

        // DELETE: api/deleteDetailPlan/5
        [ResponseType(typeof(DetailPlan))]
        [Route("api/deleteDetailPlan/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteDetailPlan(int id)
        {
            DetailPlan detailPlan = db.DetailPlans.Find(id);
            if (detailPlan == null)
            {
                return NotFound();
            }

            db.DetailPlans.Remove(detailPlan);
            db.SaveChanges();

            return Ok("DetailPlan deleted successfully.");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DetailPlanExists(int id)
        {
            return db.DetailPlans.Count(e => e.Id == id) > 0;
        }
    }
}
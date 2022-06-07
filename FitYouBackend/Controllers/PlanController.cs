using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using FitYouBackend.Models;

namespace FitYouBackend.Controllers
{
    
    public class PlanController : ApiController
    {
        private FityouContext db = new FityouContext();

        // GET: api/GetPlans
        
        [Route("api/GetPlans")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Plan> GetPlans()
        {
            foreach (Plan plan in db.Plans.ToList())
            {
                
                if (plan.InternetId.HasValue)
                {
                    plan.Internet = db.Internets.Find(plan.InternetId);
                }

                if (plan.TelecableId.HasValue)
                {
                    plan.Telecable = db.Telecables.Find(plan.TelecableId);
                }

                if (plan.TelephoneId.HasValue)
                {
                    plan.Telephone = db.Telephones.Find(plan.TelephoneId);
                }
            }


            return db.Plans.ToList();
        }

        // GET: api/GetPlanById/5
        [ResponseType(typeof(Plan))]
        [Route("api/GetPlanById/{id}")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetPlan(int id)
        {
            Plan plan = db.Plans.Find(id);

            
            if (plan == null)
            {
                return NotFound();
            }

            if (plan.InternetId.HasValue)
            {
                plan.Internet = db.Internets.Find(plan.InternetId);
            }

            if (plan.TelecableId.HasValue)
            {
                plan.Telecable = db.Telecables.Find(plan.TelecableId);
            }

            if (plan.TelephoneId.HasValue)
            {
                plan.Telephone = db.Telephones.Find(plan.TelephoneId);
            }


            return Ok(plan);
        }

        // PUT: api/PutPlan/5
        [ResponseType(typeof(void))]
        [Route("api/PutPlan/{id}")]
        [HttpPut]
        [Authorize]
        public IHttpActionResult PutPlan(int id,[FromBody] Plan plan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plan.Id)
            {
                return BadRequest();
            }

            db.Entry(plan).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Plan updated successfully.");
        }

        // POST: api/PostPlan
        [ResponseType(typeof(Plan))]
        [Route("api/PostPlan")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult PostPlan([FromBody] Plan plan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            

            db.Plans.Add(plan);
            db.SaveChanges();

            return Ok("Plan created successfully.");
        }

        // DELETE: api/DeletePlan/5
        [ResponseType(typeof(Plan))]
        [Route("api/DeletePlan/{id}")]
        [HttpDelete]
        [Authorize]
        public IHttpActionResult DeletePlan(int id)
        {
            Plan plan = db.Plans.Find(id);
            if (plan == null)
            {
                return NotFound();
            }

            db.Plans.Remove(plan);
            db.SaveChanges();

            return Ok("Plan deleted successfully.");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlanExists(int id)
        {
            return db.Plans.Count(e => e.Id == id) > 0;
        }
    }
}
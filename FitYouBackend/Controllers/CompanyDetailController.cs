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
    public class CompanyDetailController : ApiController
    {
        private FityouContext db = new FityouContext();

        // GET: api/getCompanyDetails
        [Route("api/getCompanyDetails")]
        [HttpGet]
        public IEnumerable<CompanyDetail> GetCompanyDetails()
        {
            return db.CompanyDetails.ToList();
        }

        // GET: api/getCompanyDetailById/5
        [ResponseType(typeof(CompanyDetail))]
        [Route("api/getCompanyDetailById/{id}")]
        [HttpGet]
        public IHttpActionResult GetCompanyDetail(int id)
        {
            CompanyDetail companyDetail = db.CompanyDetails.Find(id);
            if (companyDetail == null)
            {
                return NotFound();
            }

            return Ok(companyDetail);
        }

        // PUT: api/putCompanyDetailById/5
        [ResponseType(typeof(void))]
        [Route("api/putCompanyDetailById/{id}")]
        [HttpPut]
        public IHttpActionResult PutCompanyDetail(int id, [FromBody] CompanyDetail companyDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != companyDetail.Id)
            {
                return BadRequest();
            }

            db.Entry(companyDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Company_Detail updated successfully.");
        }

        // POST: api/postCompanyDetail
        [ResponseType(typeof(CompanyDetail))]
        [Route("api/postCompanyDetail")]
        [HttpPost]
        public IHttpActionResult PostCompanyDetail([FromBody] CompanyDetail companyDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CompanyDetails.Add(companyDetail);
            db.SaveChanges();

            return Ok("Company_Detail created successfully.");
        }

        // DELETE: api/deleteCompanyDetail/5
        [ResponseType(typeof(CompanyDetail))]
        [Route("api/deleteCompanyDetail/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteCompanyDetail(int id)
        {
            CompanyDetail companyDetail = db.CompanyDetails.Find(id);
            if (companyDetail == null)
            {
                return NotFound();
            }

            db.CompanyDetails.Remove(companyDetail);
            db.SaveChanges();

            return Ok("Company_Detail deleted successfully.");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyDetailExists(int id)
        {
            return db.CompanyDetails.Count(e => e.Id == id) > 0;
        }
    }
}
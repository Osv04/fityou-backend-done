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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CompanyController : ApiController
    {
        private FityouContext db = new FityouContext();

        // GET: api/getCompanies
        [Route("api/getCompanies")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Company> GetCompanies()
        {
            return db.Companies.ToList();
        }

        // GET: api/getCompanyById/5
        [ResponseType(typeof(Company))]
        [Route("api/getCompanyById/{id}")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetCompany(int id)
        {
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        // PUT: api/putCompany/5
        [ResponseType(typeof(void))]
        [Route("api/putCompany/{id}")]
        [HttpPut]
        [Authorize]
        public IHttpActionResult PutCompany(int id, [FromBody] Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != company.Id)
            {
                return BadRequest();
            }

            db.Entry(company).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Company updated successfully.");
        }

        // POST: api/postCompany
        [ResponseType(typeof(Company))]
        [Route("api/postCompany")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult PostCompany([FromBody] Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Companies.Add(company);
            db.SaveChanges();

            return Ok("Company created successfully.");
            //return CreatedAtRoute("DefaultApi", new { id = company.Id }, company);
        }

        // DELETE: api/deleteCompany/5
        [ResponseType(typeof(Company))]
        [Route("api/deleteCompany/{id}")]
        [HttpDelete]
        [Authorize]
        public IHttpActionResult DeleteCompany(int id)
        {
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            db.Companies.Remove(company);
            db.SaveChanges();

            return Ok("Company deleted successfully.");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyExists(int id)
        {
            return db.Companies.Count(e => e.Id == id) > 0;
        }
    }
}
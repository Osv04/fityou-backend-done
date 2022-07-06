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
    public class TicketsController : ApiController
    {
        private FityouContext db = new FityouContext();

        // GET: api/Tickets
        public IEnumerable<Tickets> GetTickets()
        {
            return db.Tickets;
        }

        // GET: api/Tickets/5
        [ResponseType(typeof(Tickets))]
        public IHttpActionResult GetTickets(int id)
        {
            Tickets tickets = db.Tickets.Find(id);
            if (tickets == null)
            {
                return NotFound();
            }

            return Ok(tickets);
        }

        // PUT: api/Tickets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTickets(int id, Tickets tickets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tickets.Id)
            {
                return BadRequest();
            }

            db.Entry(tickets).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tickets
        [ResponseType(typeof(Tickets))]
        public IHttpActionResult PostTickets(Tickets tickets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tickets.Add(tickets);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tickets.Id }, tickets);
        }

        // DELETE: api/Tickets/5
        [ResponseType(typeof(Tickets))]
        public IHttpActionResult DeleteTickets(int id)
        {
            Tickets tickets = db.Tickets.Find(id);
            if (tickets == null)
            {
                return NotFound();
            }

            db.Tickets.Remove(tickets);
            db.SaveChanges();

            return Ok(tickets);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TicketsExists(int id)
        {
            return db.Tickets.Count(e => e.Id == id) > 0;
        }
    }
}
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
using MVCSPA45.Models;

namespace MVCSPA45.Controllers
{
    public class vwEventsController : ApiController
    {
        private R5DiagContext db = new R5DiagContext();

        // GET: api/vwEvents
        public IQueryable<vwEvent> GetvwEvents()
        {
            return db.vwEvents;
        }

        // GET: api/vwEvents/5
        [ResponseType(typeof(vwEvent))]
        public IHttpActionResult GetvwEvent(int id)
        {
            vwEvent vwEvent = db.vwEvents.Find(id);
            if (vwEvent == null)
            {
                return NotFound();
            }

            return Ok(vwEvent);
        }

        // PUT: api/vwEvents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutvwEvent(int id, vwEvent vwEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vwEvent.idEvent)
            {
                return BadRequest();
            }

            db.Entry(vwEvent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vwEventExists(id))
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

        // POST: api/vwEvents
        [ResponseType(typeof(vwEvent))]
        public IHttpActionResult PostvwEvent(vwEvent vwEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.vwEvents.Add(vwEvent);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (vwEventExists(vwEvent.idEvent))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vwEvent.idEvent }, vwEvent);
        }

        // DELETE: api/vwEvents/5
        [ResponseType(typeof(vwEvent))]
        public IHttpActionResult DeletevwEvent(int id)
        {
            vwEvent vwEvent = db.vwEvents.Find(id);
            if (vwEvent == null)
            {
                return NotFound();
            }

            db.vwEvents.Remove(vwEvent);
            db.SaveChanges();

            return Ok(vwEvent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vwEventExists(int id)
        {
            return db.vwEvents.Count(e => e.idEvent == id) > 0;
        }
    }
}
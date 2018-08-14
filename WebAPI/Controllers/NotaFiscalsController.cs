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
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class NotaFiscalsController : ApiController
    {
        private WebAPIContext db = new WebAPIContext();

        // GET: api/NotaFiscals
        public IQueryable<NotaFiscal> GetNotaFiscals()
        {
            return db.NotaFiscals;
        }

        // GET: api/NotaFiscals/5
        [ResponseType(typeof(NotaFiscal))]
        public IHttpActionResult GetNotaFiscal(int id)
        {
            NotaFiscal notaFiscal = (NotaFiscal)db.NotaFiscals.Find(id);
            if (notaFiscal == null)
            {
                return NotFound();
            }

            return Ok(notaFiscal);
        }

        // PUT: api/NotaFiscals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNotaFiscal(int id, NotaFiscal notaFiscal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notaFiscal.NotaFiscalId)
            {
                return BadRequest();
            }

            db.Entry(notaFiscal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotaFiscalExists(id))
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

        // POST: api/NotaFiscals
        [ResponseType(typeof(NotaFiscal))]
        public IHttpActionResult PostNotaFiscal(NotaFiscal notaFiscal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NotaFiscals.Add(notaFiscal);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = notaFiscal.NotaFiscalId }, notaFiscal);
        }

        // DELETE: api/NotaFiscals/5
        [ResponseType(typeof(NotaFiscal))]
        public IHttpActionResult DeleteNotaFiscal(int id)
        {
            NotaFiscal notaFiscal = (NotaFiscal)db.NotaFiscals.Find(id);
            if (notaFiscal == null)
            {
                return NotFound();
            }

            db.NotaFiscals.Remove(notaFiscal);
            db.SaveChanges();

            return Ok(notaFiscal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NotaFiscalExists(int id)
        {
            return db.NotaFiscals.Count(e => e.NotaFiscalId == id) > 0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class NotaFiscalController : ApiController
    {
        private NotaFiscalContext db = new NotaFiscalContext();

        /// <summary>
        /// Retorna uma lista com todas as notas fiscais
        /// </summary>
        /// <returns>Lista do tipo NotaFiscal</returns>
        // GET: api/NotaFiscal
        [HttpGet]
        public IQueryable<NotaFiscal> GetNotaFiscals()
        {
            return db.NotaFiscals;
        }

        /// <summary>
        /// Retorna uma nota fiscal filtrada pelo ID
        /// </summary>
        /// <param name="id">id da nota fiscal</param>
        /// <returns>Objeto do tipo NotaFiscal</returns>
        // GET: api/NotaFiscal/5
        [ResponseType(typeof(NotaFiscal)), HttpGet]
        public async Task<IHttpActionResult> GetNotaFiscal(int id)
        {
            NotaFiscal notaFiscal = await db.NotaFiscals.FindAsync(id);
            if (notaFiscal == null)
            {
                return NotFound();
            }

            return Ok(notaFiscal);
        }

        /// <summary>
        /// Altera uma nota fiscal
        /// </summary>
        /// <param name="id">Id da nota fiscal a ser alterada</param>
        /// <param name="notaFiscal">Novas informações da nota fiscal</param>
        // PUT: api/NotaFiscal/5
        [ResponseType(typeof(void)), HttpPut]
        public async Task<IHttpActionResult> PutNotaFiscal(int id, NotaFiscal notaFiscal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notaFiscal.notaFiscalId)
            {
                return BadRequest();
            }

            db.Entry(notaFiscal).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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

        /// <summary>
        /// Insere uma nova NF no banco
        /// </summary>
        /// <param name="notaFiscal">Informações da NotaFiscal</param>
        /// <returns></returns>
        // POST: api/NotaFiscals
        [ResponseType(typeof(NotaFiscal)), HttpPost]
        public async Task<IHttpActionResult> PostNotaFiscal(NotaFiscal notaFiscal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NotaFiscals.Add(notaFiscal);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = notaFiscal.notaFiscalId }, notaFiscal);
        }

        /// <summary>
        /// Deleta uma nota fiscal
        /// </summary>
        /// <param name="id">Id da nota fiscal a ser deletada</param>
        /// <returns></returns>
        // DELETE: api/NotaFiscals/5
        [ResponseType(typeof(NotaFiscal)), HttpDelete]
        public async Task<IHttpActionResult> DeleteNotaFiscal(int id)
        {
            NotaFiscal notaFiscal = await db.NotaFiscals.FindAsync(id);
            if (notaFiscal == null)
            {
                return NotFound();
            }

            db.NotaFiscals.Remove(notaFiscal);
            await db.SaveChangesAsync();

            return Ok(notaFiscal);
        }

        [NonAction]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [NonAction]
        private bool NotaFiscalExists(int id)
        {
            return db.NotaFiscals.Count(e => e.notaFiscalId == id) > 0;
        }
    }
}
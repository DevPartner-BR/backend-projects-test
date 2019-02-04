using Application.Interfaces;
using Application.Model;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Areas.NotaFiscal.Controllers
{
    [RoutePrefix("api/notaFiscal")]
    public class NotaFiscalController : ApiController
    {
        private readonly INotaFiscalApp _notaFiscalApp;

        public NotaFiscalController(INotaFiscalApp notaFiscalApp)
        {
            this._notaFiscalApp = notaFiscalApp;
        }

        /// <summary>
        /// Obtem Todas as Notas fiscais cadastradas no sistema
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        [Route("obterTodos")]
        public HttpResponseMessage ObterTodos()
        {
            try
            {
                var result = this._notaFiscalApp.FindAll();

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Obtem uma nota fiscal pelo id
        /// </summary>
        /// <param name="id">Id da nota que se deseja Obter</param>
        [HttpGet]
        [Route("obterPorId")]
        public HttpResponseMessage ObterPorId(int id)
        {
            try
            {
                var result = this._notaFiscalApp.FindById(id);

                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Obtem uma nota fiscal pelo Numero da Nota Fiscal
        /// </summary>
        /// <param name="numero">Numero da nota fiscal que se deseja Obter</param>
        [HttpGet]
        [Route("obterPorNumeroNF")]
        public HttpResponseMessage ObterPorNumeroNF(long numero)
        {
            try
            {
                var lNotaFiscal = this._notaFiscalApp.FindByNumeroNF(numero);

                return Request.CreateResponse(HttpStatusCode.OK, lNotaFiscal);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Persiste uma nota fiscal no banco
        /// </summary>
        /// <param name="notaFiscal">Objeto de nota fiscal com os dados para serem persistidos no banco</param>
        [HttpPost]
        [Route("salvar")]
        public HttpResponseMessage Salvar([FromBody]NotaFiscalVW notaFiscal)
        {
            if (notaFiscal == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {

                this._notaFiscalApp.Persist(notaFiscal);

                return Request.CreateResponse(HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Atualiza os dados de uma nota fiscal
        /// </summary>
        /// <param name="notaFiscal">Objeto de nota fiscal com os dados para serem atualizados no banco</param>
        [HttpPut]
        [Route("atualizar")]
        public HttpResponseMessage Atualizar([FromBody]NotaFiscalVW notaFiscal)
        {
            if (notaFiscal == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                this._notaFiscalApp.Update(notaFiscal);

                return Request.CreateResponse(HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Remove os dados de uma nota fiscal do banco
        /// </summary>
        /// <param name="id">Id da nota que se deseja remover do banco</param>
        [HttpDelete]
        [Route("remover")]
        public HttpResponseMessage Remover(int id)
        {
            try
            {
                this._notaFiscalApp.Remove(id);

                return Request.CreateResponse(HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


    }
}
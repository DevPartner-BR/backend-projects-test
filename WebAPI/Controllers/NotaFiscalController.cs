using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    /// <summary>  
    /// Controller responsável pelo CRUD das Notas Fiscais
    /// </summary>  
    public class NotaFiscalController : ApiController
    {

        private INotaFiscalRepository _repository;
        private NotaFiscalService _service;

        public NotaFiscalController(INotaFiscalRepository repository, NotaFiscalService service)
        {
            _repository = repository;
            _service = service;
        }


        /// <summary>  
        /// Recebe todas as notas fiscais
        /// </summary>  
        public IHttpActionResult Get()
        {

            IList<NotaFiscal> notas = _service.ExibirNotas();

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, notas));
        }


        /// <summary>  
        /// Recebe todas as notas fiscais fornecendo o Id
        /// </summary>  
        public IHttpActionResult Get(int id)
        {

            NotaFiscal nota = _service.ExibirNota(id);

            if (nota != null)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, nota));
            }
            else
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, nota));
            }



        }

        /// <summary>  
        /// Cadastra a nota fiscal
        /// </summary>  
        public IHttpActionResult Post([FromBody]JObject json)
        {

            var obj = json.ToObject<NotaFiscal>();

            var result = _service.CriarNota(obj);

            return Ok(result);
        }


        /// <summary>  
        /// Altera a nota fiscal baseada no Id
        /// </summary>  
        public IHttpActionResult Put(int id, [FromBody]JObject json)
        {
            var obj = json.ToObject<NotaFiscal>();

            obj.notaFiscalId = id;

            var result = _service.AlterarNota(obj);

            return Ok(result);
        }


        /// <summary>  
        /// Deleta a nota fiscal fornecendo o Id
        /// </summary>  
        public IHttpActionResult Delete(int id)
        {

            NotaFiscal obj = new NotaFiscal();

            obj.notaFiscalId = id;

            var result = _service.ExcluirNota(obj);

            return Ok(result);

        }
    }
}
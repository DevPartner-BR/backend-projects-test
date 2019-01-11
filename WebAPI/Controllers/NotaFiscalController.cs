using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAPI.Models.NotaFiscal;
using System.Web.Http.ModelBinding;
using WebAPI.Models;
using System.Web.Script.Serialization;
using Application.Interfaces;
using Application.Model;
using System;

namespace WebAPI.Controllers
{

    public class NotaFiscalController : ApiController
    {

        #region Objetos/Variáveis Locais

        protected readonly INotaFiscalApplication _app;

        #endregion

        #region Construtores

        public NotaFiscalController
        (
            INotaFiscalApplication app
        )
        {
            _app = app;
        }

        #endregion

        #region Actions/Endpoints

        /// <summary>
        /// Incluir uma nova nota fiscal
        /// </summary>
        /// <remarks>
        /// Contrato
        /// 
        ///     Requisição: NotaFiscalInsertRequest
        ///     
        ///     Exemplo Requisição:
        ///     {
        ///         "DataNf": "2019-01-10",
        ///         "NumeroNf": 1000,
        ///         "ValorTotal": 5000,
        ///         "CnpjEmissorNf": "12714581000102",
        ///         "CnpjDestinatarioNf": "24505586000104"
        ///     }
        ///      
        /// 
        ///     Exemplo Resposta:
        ///     {
        ///         "Id": "6EF3FDCB-A6AE-42D7-9D61-E35CCFA8BA57",
        ///         "DataNf": "2019-01-10",
        ///         "NumeroNf": 1000,
        ///         "ValorTotal": 5000,
        ///         "CnpjEmissorNf": "12714581000102",
        ///         "CnpjDestinatarioNf": "24505586000104"
        ///     }
        ///     
        ///     Validações apresentadas em array, exemplo:
        ///     {
        ///     [
        ///         "Critica1, 
        ///         "Critica2"
        ///     ]}
        /// 
        /// </remarks>
        /// <response code="200">Sucesso na gravação - retornará os mesmos campos da requisição acrescido do Id do registro</response>
        /// <response code="400">Requisição inválida, detalhes informado no campo mensagem</response>
        /// <response code="500">Se ocorrer alguma falha no processamento da request</response>
        [HttpPost]
        [Route("api/nota-fiscal")]
        public IHttpActionResult Inserir([FromBody]NotaFiscalInsertRequest request)
        {

            try
            {

                if (!ModelState.IsValid)
                    return RespostaCritica(ModelState);

                NotaFiscalViewModel resp = _app.Adicionar
                (
                    new NotaFiscalViewModel()
                    {
                        NumeroNf = request.NumeroNf.Value,
                        DataNf = request.DataNf.Value,
                        ValorTotal = request.ValorTotal.Value,
                        CnpjEmissorNf = request.CnpjEmissorNf,
                        CnpjDestinatarioNf = request.CnpjDestinatarioNf
                    }
                );

                return Ok(resp);

            }
            catch
            {
                return StatusCode(System.Net.HttpStatusCode.InternalServerError);
            }

        }

        /// <summary>
        /// Obter a nota fiscal pelo id
        /// </summary>
        /// <remarks>
        /// Contrato
        ///
        ///     Requisição
        ///     url: [URI]/api/nota-fiscal/{guid}
        ///     
        ///     Resposta:
        ///     [
        ///         "Id": "6EF3FDCB-A6AE-42D7-9D61-E35CCFA8BA57",
        ///         "DataNf": "2019-01-10",
        ///         "NumeroNf": 1000,
        ///         "ValorTotal": 5000,
        ///         "CnpjEmissorNf": "12714581000102",
        ///         "CnpjDestinatarioNf": "24505586000104"
        ///     ]
        ///     
        /// </remarks>
        /// <returns>Os dados da nota fiscal</returns>
        /// <response code="200">Retorna a lista de registros cadastrados</response>
        /// <response code="500">Se ocorrer alguma falha no processamento da request</response>
        [HttpGet]
        [Route("api/nota-fiscal/{id:guid}")]
        public IHttpActionResult Obter(Guid id)
        {
            NotaFiscalViewModel result = _app.ObterPorId(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Obter a nota fiscal pelo número
        /// </summary>
        /// <remarks>
        /// Contrato
        ///
        ///     Requisição
        ///     url: [URI]/api/nota-fiscal/{int}
        ///     
        ///     Resposta:
        ///     [
        ///         "Id": "6EF3FDCB-A6AE-42D7-9D61-E35CCFA8BA57",
        ///         "DataNf": "2019-01-10",
        ///         "NumeroNf": 1000,
        ///         "ValorTotal": 5000,
        ///         "CnpjEmissorNf": "12714581000102",
        ///         "CnpjDestinatarioNf": "24505586000104"
        ///     ]
        ///     
        /// </remarks>
        /// <returns>Os dados da nota fiscal</returns>
        /// <response code="200">Retorna a lista de registros cadastrados</response>
        /// <response code="500">Se ocorrer alguma falha no processamento da request</response>
        [HttpGet]
        [Route("api/nota-fiscal/{numeroNf:int}")]
        public IHttpActionResult Obter(int numeroNf)
        {
            NotaFiscalViewModel result = _app.ObterPorNumeroNf(numeroNf);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Listar todas as notas fiscais
        /// </summary>
        /// <remarks>
        /// Contrato
        ///
        ///     Requisição
        ///     Nenhum parâmetro
        ///     
        ///     Resposta (array)
        ///     [
        ///         {
        ///             "Id": "6EF3FDCB-A6AE-42D7-9D61-E35CCFA8BA57",
        ///             "DataNf": "2019-01-10",
        ///             "NumeroNf": 1000,
        ///             "ValorTotal": 5000,
        ///             "CnpjEmissorNf": "12714581000102",
        ///             "CnpjDestinatarioNf": "24505586000104"
        ///         }
        ///     ]
        ///     
        /// </remarks>
        /// <returns>Lista dos registros de notas fiscais</returns>
        /// <response code="200">Retorna a lista de registros cadastrados</response>
        /// <response code="500">Se ocorrer alguma falha no processamento da request</response>
        [HttpGet]
        [Route("api/nota-fiscal/todas")]
        public IHttpActionResult Obter()
        {
            IEnumerable<NotaFiscalViewModel> result = _app.ObterTodos();
            if (result == null)
                return StatusCode(System.Net.HttpStatusCode.Found);
            return Ok(result);
        }

        /// <summary>
        /// Alterar uma nova nota fiscal existente
        /// </summary>
        /// <remarks>
        /// Contrato
        /// 
        ///     Requisição: NotaFiscalUpdateRequest
        ///     
        ///     Exemplo Requisição:
        ///     url: [URI]/api/nota-fiscal/{guid}
        ///     {
        ///         "ValorTotal": 5500,
        ///         "CnpjEmissorNf": "12714581000102",
        ///         "CnpjDestinatarioNf": "24505586000104"
        ///     }
        ///      
        /// 
        ///     Exemplo Resposta:
        ///     {
        ///         "Id": "6EF3FDCB-A6AE-42D7-9D61-E35CCFA8BA57",
        ///         "DataNf": "2019-01-10",
        ///         "NumeroNf": 1000,
        ///         "ValorTotal": 5500,
        ///         "CnpjEmissorNf": "12714581000102",
        ///         "CnpjDestinatarioNf": "24505586000104"
        ///     }
        ///     
        ///     Validações apresentadas em array, exemplo:
        ///     {
        ///     [
        ///         "Critica1, 
        ///         "Critica2"
        ///     ]}
        ///     
        ///     IMPORTANTE: Os seguintes campos não são editáveis
        ///     . Id
        ///     . NumeroNf
        ///     . DataNf
        /// 
        /// </remarks>
        /// <response code="200">Sucesso na gravação - retornará todos os campos da nota com as alterações realizadas</response>
        /// <response code="400">Requisição inválida, detalhes informado no campo mensagem</response>
        /// <response code="500">Se ocorrer alguma falha no processamento da request</response>
        [HttpPut]
        [Route("api/nota-fiscal/{id:guid}")]
        public IHttpActionResult Atualizar([FromUri] Guid id, [FromBody]NotaFiscalUpdateRequest request)
        {

            try
            {

                if (!ModelState.IsValid)
                    return RespostaCritica(ModelState);

                NotaFiscalViewModel nota = _app.ObterPorId(id);
                if (nota == null)
                    return BadRequest("Nota fiscal não encontrada");

                nota.ValorTotal = request.ValorTotal.Value;
                nota.CnpjEmissorNf = request.CnpjEmissorNf;
                nota.CnpjDestinatarioNf = request.CnpjDestinatarioNf;

                NotaFiscalViewModel resp = _app.Atualizar(nota);

                return Ok(resp);

            }
            catch
            {
                return StatusCode(System.Net.HttpStatusCode.InternalServerError);
            }

        }

        /// <summary>
        /// Excluir uma nota fiscal
        /// </summary>
        /// <remarks>
        /// Contrato
        ///
        ///     Requisição
        ///     url: [URI]/api/nota-fiscal/{guid}
        ///     
        ///     Resposta:
        ///     (apenas o status code é retornado)
        ///     
        /// </remarks>
        /// <response code="200">Nota fiscal excluída com sucesso</response>
        /// <response code="500">Se ocorrer alguma falha no processamento da request</response>
        [HttpDelete]
        [Route("api/nota-fiscal/{id:guid}")]
        public IHttpActionResult Excluir(Guid id)
        {

            try
            {
                if (_app.ObterPorId(id) == null)
                    return NotFound();

                _app.Excluir(id);
                return Ok();

            }
            catch
            {
                return StatusCode(System.Net.HttpStatusCode.InternalServerError);
            }

        }

        #endregion


        #region Métodos Locais

        /// <summary>
        /// Montar a resposta de críticas para devolver para o web-client
        /// </summary>
        /// <param name="modelState">Dicionario de ModelState</param>
        private IHttpActionResult RespostaCritica(ModelStateDictionary modelState)
        {

            IList<string> erros = modelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            string json = new JavaScriptSerializer().Serialize(erros);
            return BadRequest(json);
        }

        #endregion


    }
}
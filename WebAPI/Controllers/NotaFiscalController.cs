using Data.Dapper;
using Domain.Entities;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
    [System.Web.Http.RoutePrefix("api/notafiscal")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class NotaFiscalController : ApiController
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;

        public NotaFiscalController(INotaFiscalRepository notaFiscalRepository)
        {
            _notaFiscalRepository = notaFiscalRepository;
        }

        /// <summary>
        /// Retorna Lista de Notas Fiscais
        /// </summary>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("")]
        public IHttpActionResult RetornaNotas()
        {
            return Json(_notaFiscalRepository.RetornaListaNotas());
        }

        /// <summary>
        /// InsereNotaFiscal
        /// </summary>
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("insere")]
        [ModelStateValidationActionFilter]
        public IHttpActionResult InsereNotaFiscal([FromBody]NotaFiscal notaFiscal)
        {
            _notaFiscalRepository.InsereNotaFiscal(notaFiscal);
            return Ok();
        }

        /// <summary>
        /// InsereNotaFiscal
        /// </summary>
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("atualiza")]
        [ModelStateValidationActionFilter]
        public IHttpActionResult AtualizaNotaFiscal([FromBody]NotaFiscal notaFiscal)
        {
            _notaFiscalRepository.AtualizaNotaFiscal(notaFiscal);
            return Ok();
        }

        /// <summary>
        /// ExcluiNotaFiscal
        /// </summary>
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("exclui")]
        [ModelStateValidationActionFilter]
        public IHttpActionResult ExcluiNotaFiscal([FromBody]NotaFiscal notaFiscal)
        {
            _notaFiscalRepository.ExcluiNotaFiscal(notaFiscal);
            return Ok();
        }
    }
}
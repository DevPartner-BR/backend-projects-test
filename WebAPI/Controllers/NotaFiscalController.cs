using Application.Interfaces;
using Application.Model;
using AutoMapper;
using Domain.Entities;
using System.Collections.Generic;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [Authorize]
    [System.Web.Http.RoutePrefix("api/notafiscal")]
    public class NotaFiscalController : ApiController
    {
        private readonly INotaFiscalAppService _notaFiscalApp;

        public NotaFiscalController(INotaFiscalAppService notaFiscalApp)
        {
            _notaFiscalApp = notaFiscalApp;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("")]

        public IEnumerable<NotaFiscalViewModel> GetAll()
        {
            try
            {
                return Mapper.Map<IEnumerable<NotaFiscal>, IEnumerable<NotaFiscalViewModel>>(_notaFiscalApp.GetAll());
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        [System.Web.Http.Route("getid")]
        public NotaFiscalViewModel GetId([FromBody]NotaFiscalViewModel notaFiscal)
        {
            try
            {
                return Mapper.Map<NotaFiscal, NotaFiscalViewModel>(_notaFiscalApp.GetById(notaFiscal.Id));
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        [System.Web.Http.Route("add")]
        public IHttpActionResult Add([FromBody]NotaFiscalViewModel notaFiscal)
        {
            try
            {
                var notaFiscalObj = Mapper.Map<NotaFiscalViewModel, NotaFiscal>(notaFiscal);
                notaFiscalObj.DataCadastro = System.DateTime.Now;
                notaFiscalObj.Ativo = true;

                _notaFiscalApp.Add(notaFiscalObj);

                return Ok();
            }
            catch
            { return InternalServerError(); }
        }

        [HttpPut]
        [System.Web.Http.Route("update")]
        public IHttpActionResult Update([FromBody]NotaFiscalViewModel notaFiscal)
        {
            try
            {
                NotaFiscal result = _notaFiscalApp.GetById(notaFiscal.Id);
                if (result != null)
                {
                    result.Numero = notaFiscal.Numero;
                    result.ValorTotal = notaFiscal.ValorTotal;
                    result.Data = notaFiscal.Data;
                    result.CNPJDestinatario = notaFiscal.CNPJDestinatario;
                    result.CNPJEmissor = notaFiscal.CNPJEmissor;

                    _notaFiscalApp.Update(result);
                }
                else
                    return NotFound();

                return Ok();
            }
            catch
            { return InternalServerError(); }
        }

        [HttpDelete]
        [System.Web.Http.Route("delete")]
        public IHttpActionResult Del([FromBody]NotaFiscalViewModel notaFiscal)
        {
            try
            {
                NotaFiscal result = _notaFiscalApp.GetById(notaFiscal.Id);
                if (result != null)
                {
                    result.Ativo = false;

                    _notaFiscalApp.Update(result);
                }
                else
                    return NotFound();

                return Ok();
            }
            catch
            { return InternalServerError(); }
        }
    }
}
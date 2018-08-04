using Application.Interfaces;
using Application.Model;
using AutoMapper;
using Domain.Entities;
using System.Collections.Generic;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class NotaFiscalController : ApiController
    {
        private readonly INotaFiscalAppService _notaFiscalApp;

        public NotaFiscalController(INotaFiscalAppService notaFiscalApp)
        {
            _notaFiscalApp = notaFiscalApp;
        }

        [HttpGet]
        public IEnumerable<NotaFiscalViewModel> Get()
        {
            return Mapper.Map<IEnumerable<NotaFiscal>, IEnumerable<NotaFiscalViewModel>>(_notaFiscalApp.GetAll());
        }

        [HttpGet]
        public NotaFiscalViewModel Get(int id)
        {
            return Mapper.Map<NotaFiscal, NotaFiscalViewModel>(_notaFiscalApp.GetById(id));
        }

        [HttpPost]
        public void Post([FromBody]NotaFiscalViewModel notaFiscal)
        {
            _notaFiscalApp.Add(Mapper.Map<NotaFiscalViewModel, NotaFiscal>(notaFiscal));
        }

        [HttpPut]
        public void Put([FromBody]NotaFiscalViewModel notaFiscal)
        {
            _notaFiscalApp.Update(Mapper.Map<NotaFiscalViewModel, NotaFiscal>(notaFiscal));
        }

        [HttpDelete]
        public void Delete(int id)
        {
            NotaFiscal notaFiscal = _notaFiscalApp.GetById(id);

            if (notaFiscal != null)
                _notaFiscalApp.Remove(notaFiscal);
        }
    }
}
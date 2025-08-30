using Application.Interfaces;
using Application.Model;
using AutoMapper;
using Domain.Entities;
using System.Collections.Generic;
using System.Web.Http;

namespace WebAPI.Controllers
{
    /// <summary>
    /// CRUD de notas fiscais
    /// </summary>
    [Authorize]
    public class NotaFiscalController : ApiController
    {
        private readonly INotaFiscalAppService _notaFiscalApp;

        public NotaFiscalController(INotaFiscalAppService notaFiscalApp)
        {
            _notaFiscalApp = notaFiscalApp;
        }

        /// <summary>
        /// Retorna todas as notas ficais
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<NotaFiscalViewModel> Get()
        {
            return Mapper.Map<IEnumerable<NotaFiscal>, IEnumerable<NotaFiscalViewModel>>(_notaFiscalApp.GetAll());
        }

        /// <summary>
        /// Retorna uma nota fiscal pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public NotaFiscalViewModel Get(int id)
        {
            return Mapper.Map<NotaFiscal, NotaFiscalViewModel>(_notaFiscalApp.GetById(id));
        }

        /// <summary>
        /// Insere uma nota fiscal
        /// </summary>
        /// <param name="notaFiscal"></param>
        [HttpPost]
        public void Post([FromBody]NotaFiscalViewModel notaFiscal)
        {
            _notaFiscalApp.Add(Mapper.Map<NotaFiscalViewModel, NotaFiscal>(notaFiscal));
        }

        /// <summary>
        /// Atualiza uma nota fiscal
        /// </summary>
        /// <param name="notaFiscal"></param>
        [HttpPut]
        public void Put([FromBody]NotaFiscalViewModel notaFiscal)
        {
            _notaFiscalApp.Update(Mapper.Map<NotaFiscalViewModel, NotaFiscal>(notaFiscal));
        }

        /// <summary>
        /// Exclui uma nota fiscal
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public void Delete(int id)
        {
            NotaFiscal notaFiscal = _notaFiscalApp.GetById(id);

            if (notaFiscal != null)
                _notaFiscalApp.Remove(notaFiscal);
        }
    }
}
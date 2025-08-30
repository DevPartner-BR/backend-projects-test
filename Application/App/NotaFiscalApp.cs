using System.Collections.Generic;
using Application.Interfaces;
using Application.Model;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace Application.App
{
    public class NotaFiscalApp : INotaFiscalApp
    {
        private readonly INotaFiscalService _notaFiscalService;

        public NotaFiscalApp(INotaFiscalService notaFiscalService)
        {
            this._notaFiscalService = notaFiscalService;
        }

        public IEnumerable<NotaFiscalVW>  FindAll()
        {
            return Mapper.Map<IEnumerable<NotaFiscalVW>>(this._notaFiscalService.FindAll());
        }

        public NotaFiscalVW FindById(int id)
        {
            return Mapper.Map<NotaFiscalVW>(this._notaFiscalService.FindById(id)); ;
        }

        public NotaFiscalVW FindByNumeroNF(long numNF)
        {
            return Mapper.Map<NotaFiscalVW>(this._notaFiscalService.FindByNumeroNF(numNF)); ;
        }

        public void Persist(NotaFiscalVW notaFiscal)
        {
            NotaFiscal lNotaFiscal = Mapper.Map<NotaFiscal>(notaFiscal);

            this._notaFiscalService.Persist(lNotaFiscal);
        }


        public void Update(NotaFiscalVW notaFiscal)
        {
            NotaFiscal lNotaFiscal = Mapper.Map<NotaFiscal>(notaFiscal);

            this._notaFiscalService.Update(lNotaFiscal);
        }

        public void Remove(int id)
        {
            this._notaFiscalService.Remove(id);
        }

    }
}

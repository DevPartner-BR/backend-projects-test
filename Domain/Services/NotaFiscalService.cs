using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class NotaFiscalService : INotaFiscalService
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;

        public NotaFiscalService(INotaFiscalRepository notaFiscalRepository)
        {
            this._notaFiscalRepository = notaFiscalRepository;
        }

        public IEnumerable<NotaFiscal> FindAll()
        {
            return this._notaFiscalRepository.FindAll();
        }

        public NotaFiscal FindById(int id)
        {
            return this._notaFiscalRepository.FindById(id);
        }

        public NotaFiscal FindByNumeroNF(long numNF) {
            return this._notaFiscalRepository.FindByNumeroNF(numNF);
        }

        public void Persist(NotaFiscal notaFiscal)
        {
            NotaFiscal lNotaFiscal = this._notaFiscalRepository.FindByNumeroNF(notaFiscal.numeroNf);

            if (lNotaFiscal != null)
                throw new Exception("Nota fiscal já cadastrada no sistema!");

            this._notaFiscalRepository.Persist(notaFiscal);
        }


        public void Update(NotaFiscal notaFiscal)
        {
            this._notaFiscalRepository.Update(notaFiscal);
        }

        public void Remove(int id)
        {
            this._notaFiscalRepository.Remove(id);
        }



    }
}

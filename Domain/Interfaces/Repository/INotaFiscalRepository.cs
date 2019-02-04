using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Repository
{
    public interface INotaFiscalRepository
    {
        void Persist(NotaFiscal notaFiscal);

        IEnumerable<NotaFiscal> FindAll();

        NotaFiscal FindById(int id);

        NotaFiscal FindByNumeroNF(long numNF);

        void Update(NotaFiscal notaFiscal);

        void Remove(int id);
    }
}

using Application.Model;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface INotaFiscalApp
    {
        void Persist(NotaFiscalVW notaFiscal);

        NotaFiscalVW FindById(int id);

        NotaFiscalVW FindByNumeroNF(long numNF);

        IEnumerable<NotaFiscalVW> FindAll();

        void Update(NotaFiscalVW notaFiscal);

        void Remove(int id);
    }
}

using Domain.Entities;
using System.Collections.Generic;

namespace Data.Dapper
{
    public interface INotaFiscalRepository
    {
        List<NotaFiscal> RetornaListaNotas();

        bool InsereNotaFiscal(NotaFiscal notaFiscal);

        bool AtualizaNotaFiscal(NotaFiscal notaFiscal);

        bool ExcluiNotaFiscal(NotaFiscal notaFiscal);
    }
}
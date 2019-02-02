using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudWebAPIAspCore.Model;

namespace CrudWebAPIAspCore.Service
{
   public interface INFService
    {
        List<NotaFiscal> GetNotaFiscal();
        NotaFiscal GetNotaFiscal(int notafiscalid);
        void AddNotaFiscal(NotaFiscal item);
        void UpdateNotaFiscal(NotaFiscal item);
        void DeletaNotaFiscal(int notafiscalid);
        bool NotaFiscalExiste(int notafiscalid);

    }
}

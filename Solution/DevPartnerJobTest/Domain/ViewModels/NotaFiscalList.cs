using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModels
{
    public class NotaFiscalList
    {
        public Guid NotaFiscalId { get; set; }

        public long NumeroNF { get; set; }

        public decimal ValorTotal { get; set; }

        public DateTime DataNF { get; set; }

        public string CNPJEmissorNF { get; set; }

        public string CNPJDestinatarioNF { get; set; }
    }
}

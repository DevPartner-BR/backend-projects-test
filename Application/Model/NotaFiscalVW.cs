using System;

namespace Application.Model
{
    public class NotaFiscalVW
    {
        public int notaFiscalId { get; set; }
        public long numeroNf { get; set; }
        public decimal valorTotal { get; set; }
        public DateTime dataNf { get; set; }
        public long cnpjEmissorNf { get; set; }
        public long cnpjDestinatarioNf { get; set; }
    }
}

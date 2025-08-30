using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class NotaFiscal
    {
        public int notaFiscalId { get; set; }

        [MaxLength(20)]
        public string numeroNf { get; set; }

        public double valorTotal { get; set; }
        public DateTime dataNf { get; set; }

        [MaxLength(20)]
        public string cnpjEmissorNf { get; set; }

        [MaxLength(20)]
        public string cnpjDestinatarioNf { get; set; }
    }
}
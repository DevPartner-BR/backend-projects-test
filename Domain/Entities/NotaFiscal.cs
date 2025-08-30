using System;

namespace Domain.Entities
{
    public class NotaFiscal
    {
        public int Id { get; set; }

        public string Numero { get; set; }

        public decimal ValorTotal { get; set; }

        public DateTime Data { get; set; }

        public string CNPJEmissor { get; set; }

        public string CNPJDestinatario { get; set; }
    }
}
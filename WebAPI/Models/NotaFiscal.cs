using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class NotaFiscal
    {
        [Key]
        public int NotaFiscalId { get; set; }

        public string NumeroNF { get; set; }

        public double ValorTotal { get; set; }

        public DateTime DataNF { get; set; }

        public string CNPJEmissorNF { get; set; }

        public string CNPJDestinatarioNF { get; set; }
    }
}
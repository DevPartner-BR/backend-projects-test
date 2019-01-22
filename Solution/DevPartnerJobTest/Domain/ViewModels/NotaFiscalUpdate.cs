using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Validation;

namespace Domain.ViewModels
{
    public class NotaFiscalUpdate
    {
        [Range(0.0, double.MaxValue)]
        public decimal ValorTotal { get; set; }

        [Required]
        [CNPJ]
        [RegularExpression(@"^\d{14}$")]
        public string CNPJEmissorNF { get; set; }

        [Required]
        [CNPJ]
        [RegularExpression(@"^\d{14}$")]
        public string CNPJDestinatarioNF { get; set; }
    }
}

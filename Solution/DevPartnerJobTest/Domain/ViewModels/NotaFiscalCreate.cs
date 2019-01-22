using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Validation;

namespace Domain.ViewModels
{
    public class NotaFiscalCreate
    {
        [Range(0.0, double.MaxValue)]
        public decimal ValorTotal { get; set; }

        [Required]
        [CNPJ]
        [RegularExpression(@"^\d{14}$")] // [note] It's just a layer of validation, the CNPJAttribute is supposed to complete the work
        public string CNPJEmissorNF { get; set; }

        [Required]
        [CNPJ]
        [RegularExpression(@"^\d{14}$")]
        public string CNPJDestinatarioNF { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Model
{
    public class NotaFiscalViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O numero da nota fiscal é obrigatório.")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O valor total da nota fiscal é obrigatório.")]
        public decimal ValorTotal { get; set; }

        [Required(ErrorMessage = "A data da nota fiscal é obrigatória.")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O CNPJ do emissor da nota fiscal é obrigatório.")]
        public string CNPJEmissor { get; set; }

        [Required(ErrorMessage = "O CNPJ do destinatário da nota fiscal é obrigatório.")]
        public string CNPJDestinatario { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class NotaFiscal
    {
        
        public int notaFiscalId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo numeroNf Obrigatório!")]
        public string numeroNf { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo valorTotal Obrigatório!")]
        public decimal valorTotal { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo dataNf Obrigatório!")]
        public DateTime dataNf { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo cnpjEmissorNf Obrigatório!"), StringLength(14,ErrorMessage = "Tamanho do CNPJ inválido", MinimumLength = 14)]
        public string cnpjEmissorNf { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo cnpjDestinatarioNf Obrigatório!"), StringLength(14, ErrorMessage = "Tamanho do CNPJ inválido", MinimumLength = 14)]
        public string cnpjDestinatarioNf { get; set; }

    }
}
using System;
using System.ComponentModel.DataAnnotations;
using WebAPI.Validations;

namespace WebAPI.Models.NotaFiscal
{

    /// <summary>
    /// Modelo de requisição de atualização de nota fiscal
    /// </summary>
    public class NotaFiscalUpdateRequest
    {

        /// <summary>
        /// Valor total da nota fiscal
        /// </summary>
        [Required(ErrorMessage = "O valor total da nota fiscal deve ser informado")]
        [Range(0.01D, 999999999999999D, ErrorMessage = "O valor total da nota fiscal deve estar entre 0 e 999.999.999.999.999,99")]
        public decimal? ValorTotal { get; set; }

        /// <summary>
        /// Cnpj do emissor da nota fiscal
        /// </summary>
        [Required(ErrorMessage = "O Cnpj do emissor deve ser informado")]
        [CnpjValidation(ErrorMessage = "Cnpj do emissor inválido")]
        public string CnpjEmissorNf { get; set; }

        /// <summary>
        /// Cnpj do destinatário da nota fiscal
        /// </summary>
        [Required(ErrorMessage = "O Cnpj do destinatário deve ser informado")]
        [CnpjValidation(ErrorMessage = "Cnpj do destinatário inválido")]
        public string CnpjDestinatarioNf { get; set; }

    }
}
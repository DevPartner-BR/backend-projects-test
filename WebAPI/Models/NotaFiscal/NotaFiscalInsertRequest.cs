using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.NotaFiscal
{

    /// <summary>
    /// Modelo de requisição de inclusão de nota fiscal
    /// </summary>
    public class NotaFiscalInsertRequest : NotaFiscalUpdateRequest
    {

        /// <summary>
        /// Data de emissão da nota fiscal
        /// </summary>
        [Required(ErrorMessage = "A data de emissão da nota fiscal deve ser informada")]
        public DateTime? DataNf { get; set; }

        /// <summary>
        /// Número da nota fiscal
        /// </summary>
        [Required(ErrorMessage = "O número da nota fiscal deve ser informado")]
        public int? NumeroNf { get; set; }


    }
}
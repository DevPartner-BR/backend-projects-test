using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.NotaFiscal
{
    public class NotaFiscalInsertRequest : NotaFiscalUpdateRequest
    {

        /// <summary>
        /// Data de emissão da nota fiscal
        /// </summary>
        [Required(ErrorMessage = "A data de emissão da nota fiscal deve ser informada")]
        public DateTime? DataNf { get; set; }


    }
}
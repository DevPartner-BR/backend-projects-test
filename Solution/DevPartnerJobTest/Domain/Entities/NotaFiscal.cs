using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    // [note] Creating the model class
    [Table("NotaFiscal")] // [note] This attribute is accessory in this case
    public class NotaFiscal
    {
        [Key]
        public Guid NotaFiscalId { get; set; }

        // [note] This attribute leaves the Database to generate numbers increasingly
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public long NumeroNF { get; set; }

        [Required]
        public decimal ValorTotal { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataNF { get; set; }

        [StringLength(14)]
        [Required]
        public string CNPJEmissorNF { get; set; }

        [StringLength(14)]
        [Required]
        public string CNPJDestinatarioNF { get; set; }

    }
}

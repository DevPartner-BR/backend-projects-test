using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class NotaFiscal
    {
        [Key]
        public int notaFiscalId            {get;set;}

        [Index("IX_NumeroNf", 1, IsUnique = true)]
        public long numeroNf               {get;set;}
        public decimal valorTotal          {get;set;}
        public DateTime dataNf             {get;set;}
        public long cnpjEmissorNf          {get;set;}
        public long cnpjDestinatarioNf     {get;set;}

    }
}

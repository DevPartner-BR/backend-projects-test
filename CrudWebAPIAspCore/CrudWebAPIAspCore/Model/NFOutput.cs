using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudWebAPIAspCore.Model
{
    public class NFOutput
    {
        public int notaFiscalId { get; set; }
        public int numeroNf { get; set; }
        public float valorTotal { get; set; }
        public DateTime dataNf { get; set; }
        public string cnpjEmissorNf { get; set; }
        public string cnpjDestinatarioNf { get; set; }
    }
}

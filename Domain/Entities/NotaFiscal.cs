using Newtonsoft.Json;
using System;

namespace Domain.Entities
{
    public class NotaFiscal
        {
        [JsonProperty("notaFiscalId")]
        public int notaFiscalId { get; set; }

        [JsonProperty("numeroNf")]
        public string numeroNf { get; set; }

        [JsonProperty("valorTotal")]
        public int valorTotal { get; set; }

        [JsonProperty("dataNf")]
        public DateTime dataNf { get; set; }

        [JsonProperty("cnpjEmissorNf")]
        public string cnpjEmissorNf { get; set; }

        [JsonProperty("cnpjDestinatarioNf")]
        public string cnpjDestinatarioNf { get; set; }
        }
    }
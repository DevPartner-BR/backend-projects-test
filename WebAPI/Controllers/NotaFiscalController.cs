using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{

    public class NotaFiscalController : ApiController
    {
        /// <summary>
        /// Obter a lista de todas as notas fiscais
        /// </summary>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Obter a nota fiscal pelo Id
        /// </summary>
        /// <param name="id">Id da nota fiscal</param>
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Incluir uma nova nota fiscal
        /// </summary>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// Alterar uma nota fiscal existente
        /// </summary>
        /// <param name="id">Id da nota fiscal</param>
        /// <param name="value">Dados da nota</param>
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Excluir uma nova fiscal existente
        /// </summary>
        /// <param name="id">Id da nota fiscal</param>
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class NotaFiscalRepository : RepositorioBase<NotaFiscal>, INotaFiscalRepository
    {

        #region Construtores

        /// <summary>
        /// Cria uma nova instância do repositório de nota fiscal
        /// </summary>
        /// <param name="ctx">Contexto de banco de dados</param>
        public NotaFiscalRepository(SystemContext ctx) : base(ctx) {}

        #endregion

        #region Metodos Públicos/Overrides

        /// <summary>
        /// Obter nota fiscal pelo Id
        /// </summary>
        /// <param name="id">Id da nota fiscal</param>
        public override NotaFiscal ObterPorId(Guid id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Obter todos os registros de notas fiscais
        /// </summary>
        public override IEnumerable<NotaFiscal> ObterTodos()
        {
            return _dbSet;
        }

        /// <summary>
        /// Obter nota fiscal pelo número da mesma
        /// </summary>
        /// <param name="numeroNF">Número da nota fiscal</param>
        public NotaFiscal ObterPorNumeroNf(int numeroNF)
        {
            return _dbSet.Where(x => x.NumeroNf.Equals(numeroNF)).FirstOrDefault();
        }

        #endregion

    }
}

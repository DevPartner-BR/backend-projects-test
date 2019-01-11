using Domain.Interfaces;

namespace Data.Context.UnitOfWork
{

    public class UnitOfWork : IUnitOfWork
    {

        #region Objetos/Variáveis Locais

        protected readonly SystemContext _ctx;

        #endregion

        #region Construtores

        /// <summary>
        /// Cria uma nova instância de UnitOfWork
        /// </summary>
        /// <param name="ctx">Contexto de banco de dados</param>
        public UnitOfWork(SystemContext ctx)
        {
            _ctx = ctx;
        }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Salvar mudanças do contexto na base de dados, persistindo os dados incluídos, alterados e excluídos (commit)
        /// </summary>
        public void SalvarMudancas()
        {
            _ctx.SaveChanges();
        }

        /// <summary>
        /// Liberar recursos
        /// </summary>
        public void Dispose()
        {
            _ctx.Dispose();
        }

        #endregion

    }

}

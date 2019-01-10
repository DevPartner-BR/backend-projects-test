using System;

namespace Domain.Interfaces
{

    public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// Salvar mudanças do contexto na base de dados, persistindo os dados incluídos, alterados e excluídos (commit)
        /// </summary>
        void SalvarMudancas();

    }

}

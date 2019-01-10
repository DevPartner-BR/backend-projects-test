using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IApplicationCrud<TViewModel> where TViewModel: IApplicationViewModel
    {

        /// <summary>
        /// Adicionar um registro ao contexto
        /// </summary>
        /// <param name="entity">Entidade a ser adicionada</param>
        TViewModel Adicionar(TViewModel entity);

        /// <summary>
        /// Busca um registro pelo id do mesmo
        /// </summary>
        /// <param name="id">Id do registro</param>
        TViewModel ObterPorId(Guid id);

        /// <summary>
        /// Obter todos os registros da entidade
        /// </summary>
        IEnumerable<TViewModel> ObterTodos();

        /// <summary>
        /// Atualizar um registro de uma entidade
        /// </summary>
        /// <param name="view">ViewModel da entidade a ser atualizada</param>
        TViewModel Atualizar(TViewModel view);

        /// <summary>
        /// Excluir o registro da entidade
        /// </summary>
        /// <param name="id">Id do registro a ser excluído</param>
        void Excluir(Guid id);

    }
}

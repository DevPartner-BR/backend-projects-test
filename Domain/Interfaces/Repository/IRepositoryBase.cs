using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : EntityBase<TEntity>
    {

        /// <summary>
        /// Adicionar um registro ao contexto
        /// </summary>
        /// <param name="entidade">Entidade a ser adicionada</param>
        TEntity Adicionar(TEntity entidade);
        
        /// <summary>
        /// Busca um registro pelo id do mesmo
        /// </summary>
        /// <param name="id">Id do registro</param>
        TEntity ObterPorId(Guid id);

        /// <summary>
        /// Obter todos os registros da entidade
        /// </summary>
        IEnumerable<TEntity> ObterTodos();

        /// <summary>
        /// Atualizar todos os registros da entidade
        /// </summary>
        /// <param name="entity">Entidade a ser atualizada</param>
        void Atualizar(TEntity entity);

        /// <summary>
        /// Excluir o registro da entidade
        /// </summary>
        /// <param name="id">Id do registro a ser excluído</param>
        void Excluir(Guid id);

        /// <summary>
        /// Efetiva a mudança no contexto
        /// </summary>
        int SalvarMudancas();
        //TODO: Verificar necessidade

    }
}

using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public abstract class ServiceBase<TEntity, TRepository> : IServiceBase<TEntity> where TEntity : EntityBase<TEntity> where TRepository : IRepositoryBase<TEntity>
    {

        #region Objetos/Variáveis Locais

        protected TRepository _repository;

        #endregion

        #region Construtores

        /// <summary>
        /// Cria uma nova instância do serviço de domínio
        /// </summary>
        /// <param name="repository"></param>
        public ServiceBase(TRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region Métodos Públicos/Overrides

        /// <summary>
        /// Adicionar um registro ao contexto
        /// </summary>
        /// <param name="entity">Entidade a ser adicionada</param>
        public virtual TEntity Adicionar(TEntity entity)
        {
            if (!entity.EstaValido())
                return entity;

            return _repository.Adicionar(entity);
        }

        /// <summary>
        /// Obter todos os registros da entidade
        /// </summary>
        public IEnumerable<TEntity> ObterTodos() => _repository.ObterTodos();

        /// <summary>
        /// Busca um registro pelo id do mesmo
        /// </summary>
        /// <param name="id">Id do registro</param>
        public TEntity ObterPorId(Guid id) => _repository.ObterPorId(id);

        /// <summary>
        /// Atualizar todos os registros da entidade
        /// </summary>
        /// <param name="entity">Entidade a ser atualizada</param>
        public virtual TEntity Atualizar(TEntity entity)
        {
            if (!entity.EstaValido())
                return entity;

            return _repository.Atualizar(entity);
        }

        /// <summary>
        /// Excluir o registro da entidade
        /// </summary>
        /// <param name="id">Id do registro a ser excluído</param>
        public virtual void Excluir(Guid id)
        {
            _repository.Excluir(id);
        }

        #endregion

        #region Dispose

        public virtual void Dispose()
        {
            _repository.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}

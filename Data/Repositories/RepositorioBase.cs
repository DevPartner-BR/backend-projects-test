using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{

    public abstract class RepositorioBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase<TEntity>
    {

        #region Objetos/Variáveis locais

        protected SystemContext _ctx;
        protected DbSet<TEntity> _dbSet;

        #endregion

        /// <summary>
        /// Cria uma nova instância do repositório
        /// </summary>
        /// <param name="ctx"></param>
        public RepositorioBase(SystemContext ctx)
        {
            _ctx = ctx;
            _dbSet = _ctx.Set<TEntity>();
        }

        /// <summary>
        /// Obter registro pelo Id
        /// </summary>
        /// <param name="id">Id do registro</param>
        public abstract TEntity ObterPorId(Guid id);

        /// <summary>
        /// Obter todos os registros
        /// </summary>
        public abstract IEnumerable<TEntity> ObterTodos();

        /// <summary>
        /// Adicionar registro no contexto
        /// </summary>
        /// <param name="entity">Entidade a ser adicionada</param>
        public virtual TEntity Adicionar(TEntity entity)
        {
            return _dbSet.Add(entity);
        }

        /// <summary>
        /// Atualizar registro no contexto
        /// </summary>
        /// <param name="entity">Entidade a ser atualizada</param>
        public virtual TEntity Atualizar(TEntity entity)
        {
            _ctx.Entry<TEntity>(entity).State = EntityState.Modified;
            return _ctx.Entry<TEntity>(entity).Entity;
        }

        /// <summary>
        /// Excluir registro do contexto
        /// </summary>
        /// <param name="id">Id do registro a ser excluído</param>
        public virtual void Excluir(Guid id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        /// <summary>
        /// Liberar recursos
        /// </summary>
        public virtual void Dispose()
        {
            _ctx.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}

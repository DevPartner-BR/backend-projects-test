using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    /// <summary>
    /// Classe abstrata de entidade com Id
    /// </summary>
    /// <typeparam name="T">Tipo de entidade</typeparam>
    public abstract class EntityIdBase<T> : EntityBase<T> where T : EntityIdBase<T>
    {

        #region Objetos/Variáveis Locais

        /// <summary>
        /// Id do registro
        /// </summary>
        protected Guid? _id = null;

        #endregion

        #region Construtores

        /// <summary>
        ///  Cria uma nova instância da entidade
        /// </summary>
        public EntityIdBase() : base()
        {
            Id = Guid.NewGuid();
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Id do registro
        /// </summary>
        public Guid? Id {
            get
            {
                if (!_id.HasValue)
                    _id = Guid.NewGuid();
                return _id;

                
            }
            protected set { _id = value; }
        }

        #endregion

        #region Métodos Públicos/Overrides

        /// <summary>
        /// Compara os dois objetos
        /// </summary>
        /// <param name="obj">Objeto para comparação</param>
        public override bool Equals(object obj)
        {
            var compareTo = obj as EntityIdBase<T>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        /// <summary>
        /// Obtém o HashCode 
        /// </summary>
        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 900) + Id.GetHashCode();
        }

        /// <summary>
        /// Obtém a string do objeto
        /// </summary>
        public override string ToString()
        {
            return $"{GetType().Name} - Id = {Id}";
        }

        #endregion

    }

}

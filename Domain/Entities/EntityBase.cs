using Domain.Interfaces.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Domain.Entities
{

    /// <summary>
    /// Classe abstrata de entidade
    /// </summary>
    /// <typeparam name="T">Tipo de objeto</typeparam>
    public abstract class EntityBase<T> : AbstractValidator<T>, IEntity
        where T : EntityBase<T>
    {

        #region Construtores

        /// <summary>
        /// Cria uma nova instância da entidade
        /// </summary>
        protected EntityBase()
        {
            ValidationResult = new ValidationResult();
        }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Resultado da validação
        /// </summary>
        public ValidationResult ValidationResult { get; protected set; }

        public string NomeEntidade()
        {
            return $"{GetType().Name}";
        }

        #endregion

        #region Métodos Abstratos

        /// <summary>
        /// Verifica se o registro está válido
        /// </summary>
        public abstract bool EstaValido();

        #endregion

        #region Overrides

        /// <summary>
        /// Compara os dois objetos
        /// </summary>
        /// <param name="obj">Objeto para comparação</param>
        public override bool Equals(object obj)
        {
            var compareTo = obj as EntityBase<T>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return false;
        }

        /// <summary>
        /// Obtém o HashCode 
        /// </summary>
        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 976);
        }

        /// <summary>
        /// Obtém a string do objeto
        /// </summary>
        public override string ToString()
        {
            return $"{GetType().Name}";
        }

        #endregion

        #region Métodos Estáticos

        /// <summary>
        /// Compara os dois objetos
        /// </summary>
        /// <param name="a">Objeto A</param>
        /// <param name="b">Objeto B</param>
        public static bool operator ==(EntityBase<T> a, EntityBase<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;

            return a.Equals(b);
        }

        /// <summary>
        /// Compara os dois objetos
        /// </summary>
        /// <param name="a">Objeto A</param>
        /// <param name="b">Objeto B</param>
        public static bool operator !=(EntityBase<T> a, EntityBase<T> b)
        {
            return !(a == b);
        }

        #endregion

        
    }

}

namespace Domain.Interfaces.Entities
{

    /// <summary>
    /// Interface para controle de tipo de objetos em camadas suberiores (where ...)
    /// </summary>
    public interface IEntity {


        /// <summary>
        /// Retorna o nome da entidade
        /// </summary>
        string NomeEntidade();

    }

}

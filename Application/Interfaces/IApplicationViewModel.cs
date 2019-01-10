using FluentValidation.Results;
using System.Collections.Generic;

namespace Application.Interfaces
{

    /// <summary>
    /// Interface para controle de tipo de objeto para view model application
    /// </summary>
    public interface IApplicationViewModel
    {

        /// <summary>
        /// Adicionar uma lista de críticas
        /// </summary>
        /// <param name="criticas">Lista de críticas</param>
        void AdicionarCriticas(IEnumerable<ValidationFailure> criticas);

        /// <summary>
        /// Retornar a lista de críticas
        /// </summary>
        /// <returns></returns>
        IEnumerable<ValidationFailure> ObterCriticas();

    }

}

using Application.Interfaces;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Application.Model
{
    public class NotaFiscalViewModel : IApplicationViewModel
    {

        #region Objetos/Variáveis locais

        private readonly IList<ValidationFailure> _criticas;

        #endregion

        #region Construtores

        /// <summary>
        /// Cria uma nova instância da ViewMOdel
        /// </summary>
        public NotaFiscalViewModel()
        {
            _criticas = new List<ValidationFailure>();
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Id da nota fiscal
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Número da nota fiscal
        /// </summary>
        public int NumeroNf { get; set; }

        /// <summary>
        /// Valor todal da nota fiscal
        /// </summary>
        public decimal ValorTotal { get; set; }

        /// <summary>
        /// Data de emissão da nota fiscal
        /// </summary>
        public DateTime DataNf { get; set; }

        /// <summary>
        /// Cnpj do emissor da nota fiscal
        /// </summary>
        public string CnpjEmissorNf { get; set; }

        /// <summary>
        /// Cnpj do destinatário da nota fiscal
        /// </summary>
        public string CnpjDestinatarioNf { get; set; }

        #endregion

        #region Métodos públicos

        /// <summary>
        /// Adicionar uma lista de críticas
        /// </summary>
        /// <param name="criticas">Lista de críticas</param>
        public void AdicionarCriticas(IEnumerable<ValidationFailure> criticas)
        {
            ((List<ValidationFailure>)_criticas).AddRange(criticas);
        }

        /// <summary>
        /// Retornar a lista de críticas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ValidationFailure> ObterCriticas()
        {
            return _criticas;
        }

        #endregion


    }

}

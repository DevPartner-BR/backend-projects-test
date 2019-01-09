using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class NotaFiscal : EntityIdBase<NotaFiscal>
    {

        #region Objetos/Variáveis Locais

        #endregion

        #region Construtores

        #endregion

        #region Propriedades

        // NotaFiscalId -> Campo Id

        /// <summary>
        /// Número da nota fiscal
        /// </summary>
        public int NumeroNf { get; set; }

        /// <summary>
        /// Total total da nota
        /// </summary>
        public decimal ValorTotal { get; set; }

        /// <summary>
        /// Data de emissão da nota fiscal
        /// </summary>
        public DateTime? DataNf { get; set; }

        /// <summary>
        /// Cnpj do emissor da nota fiscal
        /// </summary>
        public string CnpjEmissorNf { get; set; }


        /// <summary>
        /// Cnpj do destinatário da nota fiscal
        /// </summary>
        public string CnpjDestinatarioNf { get; set; }

        #endregion

        #region Métodos Locais

        #endregion

        #region Métodos Públicos / Overrides

        /// <summary>
        /// Verifica se o registro está válido
        /// </summary>
        public override bool EstaValido()
        {

            RuleFor(c => c.NumeroNf)
                .GreaterThan(0)
                .WithMessage("O número da nota fiscal deve ser maior do que 0 (zero).");

            RuleFor(c => c.ValorTotal)
                .GreaterThan(0)
                .WithMessage("O valor total da nota deve ser maior do que 0 (zero)");

            RuleFor(c => c.DataNf)
                .NotNull()
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("A data de emissão da nota não pode ser superior a data atual");


            RuleFor(c => c.CnpjEmissorNf)
                .NotNull()
                .WithMessage("O Cnpj do emissor deve ser informado");

            RuleFor(c => c.CnpjDestinatarioNf)
                .NotNull()
                .WithMessage("O Cnpj do destinatário deve ser informado");

            //TODO: Incluir validação dos cnpjs

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        #endregion

    }

}

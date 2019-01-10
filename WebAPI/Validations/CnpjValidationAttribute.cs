using DevpartnerHelper.Functions;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Validations
{


    public class CnpjValidationAttribute : ValidationAttribute
    {

        /// <summary>
        /// Cria uma nova instância do atributo
        /// </summary>
        public CnpjValidationAttribute() : base("Cnpj inválido")
        {
        }

        /// <summary>
        /// Determina se o objeto é válido
        /// </summary>
        /// <param name="value">Objeto a ser validado</param>
        public override bool IsValid(object value)
        {

            if (value == null)
                return false;

            return Validadores.VerificarCnpj(value.ToString());
        }

    }
}
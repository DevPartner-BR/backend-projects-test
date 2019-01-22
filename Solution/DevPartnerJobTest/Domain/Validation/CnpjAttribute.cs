using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Validation
{
    public class CNPJAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string cnpj)
            {
                return IsCNPJValid(cnpj);
            }
            return false;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string cnpj)
            {
                var isValid = IsCNPJValid(cnpj);
                if (isValid)
                    return ValidationResult.Success;
                //
                return new ValidationResult("CNPJ isn't in the correct format");
            }
            //
            return new ValidationResult("CNPJ must be a string");
        }

        // [note] This method just pretends to validate a CNPJ, it's not the main purpose of the test
        /// <summary>
        /// This method pretends to validate a CNPJ.
        /// </summary>
        /// <param name="cnpj">The CNPJ to validate, only numbers, 14 digits</param>
        /// <returns>true if it's valid, otherwise false</returns>
        private bool IsCNPJValid(string cnpj)
        {
            if (cnpj == null)
                throw new ArgumentNullException(nameof(cnpj));
            return cnpj.Length == 14;
        }
    }
}

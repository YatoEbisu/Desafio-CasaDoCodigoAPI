using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Api.Extensions
{
    public class IsDateBeforeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var date = (DateTime)value;
                if (date <= DateTime.Now)
                {
                    return new ValidationResult("A data deve ser superior a data atual");
                }
            }
            catch (Exception)
            {
                return new ValidationResult("Data em formato inválido");
            }

            return ValidationResult.Success;
        }
    }
}

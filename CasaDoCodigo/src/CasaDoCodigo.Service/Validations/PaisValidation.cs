using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CasaDoCodigo.Domain.Entities;
using FluentValidation;

namespace CasaDoCodigo.Service.Validations
{
    public class PaisValidation : AbstractValidator<Pais>
    {
        public PaisValidation()
        {
            RuleFor(y => y.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}

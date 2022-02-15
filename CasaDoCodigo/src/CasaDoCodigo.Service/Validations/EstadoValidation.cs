using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasaDoCodigo.Domain.Entities;
using FluentValidation;

namespace CasaDoCodigo.Service.Validations
{
    public class EstadoValidation : AbstractValidator<Estado>
    {
        public EstadoValidation()
        {
            RuleFor(y => y.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(y => y.PaisId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}

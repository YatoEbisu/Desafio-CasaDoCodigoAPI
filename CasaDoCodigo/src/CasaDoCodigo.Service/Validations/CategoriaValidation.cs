using CasaDoCodigo.Domain.Entities;
using FluentValidation;

namespace CasaDoCodigo.Service.Validations
{
    public class CategoriaValidation : AbstractValidator<Categoria>
    {
        public CategoriaValidation()
        {
            RuleFor(y => y.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}

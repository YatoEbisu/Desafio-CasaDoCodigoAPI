using CasaDoCodigo.Domain.Entities;
using FluentValidation;
using FluentValidation.Validators;

namespace CasaDoCodigo.Service.Validations
{
    public class AutorValidation : AbstractValidator<Autor>
    {
        public AutorValidation()
        {
            RuleFor(y => y.Email)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .MaximumLength(50).WithMessage("O campo {PropertyName} deve ter no máximo {MaxLength} caracteres.")
                .EmailAddress(EmailValidationMode.Net4xRegex).WithMessage("E-mail em formato inválido.");

            RuleFor(y => y.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .MaximumLength(50).WithMessage("O campo {PropertyName} deve ter no máximo {MaxLength} caracteres.");

            RuleFor(y => y.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .MaximumLength(400).WithMessage("O campo {PropertyName} deve ter no máximo {MaxLength} caracteres.");
        }
    }
}

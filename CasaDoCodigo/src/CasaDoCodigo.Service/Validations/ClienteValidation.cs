using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Service.Methods;
using FluentValidation;
using FluentValidation.Validators;

namespace CasaDoCodigo.Service.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(y => y.Email)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .EmailAddress(EmailValidationMode.Net4xRegex);

            RuleFor(y => y.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(y => y.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(y => y.Sobrenome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(y => y.Documento)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(f => CpfCnpjUtils.IsValid(f.Documento)).Equal(true)
                .WithMessage("O documento fornecido é inválido.");

            RuleFor(y => y.Complemento)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(y => y.Cidade)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(y => y.PaisId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(y => y.Telefone)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(y => y.CEP)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
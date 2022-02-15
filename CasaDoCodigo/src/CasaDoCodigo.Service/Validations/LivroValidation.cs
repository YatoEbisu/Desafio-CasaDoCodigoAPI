using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasaDoCodigo.Domain.Entities;
using FluentValidation;

namespace CasaDoCodigo.Service.Validations
{
    public class LivroValidation : AbstractValidator<Livro>
    {
        public LivroValidation()
        {
            RuleFor(y => y.Titulo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(y => y.Resumo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .MaximumLength(500).WithMessage("O campo {PropertyName} deve ter no máximo {MaxLength} caracteres.");

            RuleFor(y => y.Preco)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(y => y.NrPaginas)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(y => y.ISBN)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(y => y.CategoriaId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(y => y.AutorId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}

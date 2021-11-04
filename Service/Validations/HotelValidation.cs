using FluentValidation;
using Domain.Entities;

namespace Service.Validations
{
    public class HotelValidation : AbstractValidator<Hotel>
    {
        /// <summary>Valida propriedades da entity Hotel.</summary>
        public HotelValidation()
        {
            RuleFor(c => c.CNPJ)
                .NotEmpty().WithMessage("Preencha este campo.")
                .NotNull().WithMessage("Preencha este campo.")
                .Length(14).WithMessage("Tamanho do CNPJ deve ser de 14 caracteres.");

            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("Preencha este campo.")
                .NotNull().WithMessage("Preencha este campo.");

            RuleFor(c => c.Endereco)
               .NotEmpty().WithMessage("Preencha este campo.")
               .NotNull().WithMessage("Preencha este campo.");

            RuleFor(c => c.Nome)
               .NotEmpty().WithMessage("Preencha este campo.")
               .NotNull().WithMessage("Preencha este campo.");
        }
    }
}

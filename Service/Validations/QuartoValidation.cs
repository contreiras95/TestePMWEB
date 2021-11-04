using FluentValidation;
using Domain.Entities;

namespace Service.Validations
{
    public class QuartoValidation : AbstractValidator<Quarto>
    {
        /// <summary>Valida propriedades da entity Quarto.</summary>
        public QuartoValidation()
        {
            RuleFor(c => c.NumeroAdultos)
                .NotEmpty().WithMessage("Preencha este campo.")
                .NotNull().WithMessage("Preencha este campo.");

            RuleFor(c => c.NumeroCriancas)
                .NotEmpty().WithMessage("Preencha este campo.")
                .NotNull().WithMessage("Preencha este campo.");

            RuleFor(c => c.NumeroOcupantes)
               .NotEmpty().WithMessage("Preencha este campo.")
               .NotNull().WithMessage("Preencha este campo.");

            RuleFor(c => c.Preco)
              .NotEmpty().WithMessage("Preencha este campo.")
              .NotNull().WithMessage("Preencha este campo.")
              .NotEqual(0).WithMessage("Preencha este campo.");

            RuleFor(c => c.HotelID)
              .NotEmpty().WithMessage("Preencha este campo.")
              .NotNull().WithMessage("Preencha este campo.");

            RuleFor(c => c.Nome)
               .NotEmpty().WithMessage("Preencha este campo.")
               .NotNull().WithMessage("Preencha este campo.");
        }
    }
}

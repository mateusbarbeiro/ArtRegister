using FluentValidation;
using ArtRegister.Domain.Models;

namespace ArtRegister.Application.Validators
{
    /// <summary>
    /// Validação para objeto do tipo seção
    /// </summary>
    public class SectionsValidator : AbstractValidator<Sections>
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public SectionsValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please enter the name.")
                .NotNull().WithMessage("Please enter the name.");
        }
    }
}

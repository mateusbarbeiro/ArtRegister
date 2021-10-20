using FluentValidation;
using ArtRegister.Domain.Models;

namespace ArtRegister.Application.Validators
{
    /// <summary>
    /// Validação para objeto do tipo usuário
    /// </summary>
    public class ProductsValidator : AbstractValidator<Products>
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public ProductsValidator()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please enter the description.")
                .NotNull().WithMessage("Please enter the description.");
        }
    }
}

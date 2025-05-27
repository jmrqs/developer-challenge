using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Validator for GetSaleCommand
/// </summary>
public class GetSaleValidator : AbstractValidator<GetSaleCommand>
{
    /// <summary>
    /// Initializes validation rules for GetSaleCommand
    /// </summary>
    public GetSaleValidator()
    {
        /// <summary>
        /// Validates that the page number is provided and greater than zero.
        /// </summary>
        RuleFor(x => x.PageNumber)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("Sale ID is required and greather than 0");
    }
}
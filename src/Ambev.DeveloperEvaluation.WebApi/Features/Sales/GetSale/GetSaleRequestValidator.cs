using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

/// <summary>
/// Validator for GetSaleRequest
/// </summary>
public class GetSaleRequestValidator : AbstractValidator<GetSaleRequest>
{
    /// <summary>
    /// Initializes validation rules for GetSaleRequest
    /// </summary>
    public GetSaleRequestValidator()
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

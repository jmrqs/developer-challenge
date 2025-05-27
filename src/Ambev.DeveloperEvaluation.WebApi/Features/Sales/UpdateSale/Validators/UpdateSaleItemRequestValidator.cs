using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale.Request;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale.Validators;

/// <summary>
/// Validator for SaleItemRequest that defines validation rules for each item in a sale.
/// </summary>
public class UpdateSaleItemRequestValidator : AbstractValidator<UpdateSaleItemRequest>
{
    /// <summary>
    /// Initializes a new instance of the SaleItemRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - ProductId: Must not be empty
    /// - Quantity: Must be greater than zero
    /// - UnitPrice: Must be greater than zero
    /// </remarks>
    public UpdateSaleItemRequestValidator()
    {
        RuleFor(item => item.ProductId)
            .NotEmpty().WithMessage("ProductId is required.");

        RuleFor(item => item.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than zero.");

        RuleFor(item => item.UnitPrice)
            .GreaterThan(0).WithMessage("UnitPrice must be greater than zero.");
    }
}

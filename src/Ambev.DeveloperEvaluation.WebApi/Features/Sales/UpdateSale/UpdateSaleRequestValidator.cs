using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.Validators;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Validator for UpdateSaleRequest that defines validation rules for user creation.
/// </summary>
public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the UpdateSaleRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - SaleId: Must not be empty
    /// - Items: Must have at least one item, and each item must be valid
    /// </remarks>
    public UpdateSaleRequestValidator()
    {
        RuleFor(sale => sale.SaleId)
            .NotEmpty().WithMessage("SaleId is required.");

        RuleFor(sale => sale.SaleItems)
            .NotEmpty().WithMessage("At least one item is required.")
            .ForEach(item => item.SetValidator(new UpdateSaleItemRequestValidator()));
    }

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

}
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale.Validators;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.Validators;

/// <summary>
/// Validator for UpdateSaleRequest that defines validation rules for user creation.
/// </summary>
public class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the UpdateSaleRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - SaleId: Must not be empty
    /// - Items: Must have at least one item, and each item must be valid
    /// </remarks>
    public UpdateSaleValidator()
    {
        RuleFor(sale => sale.SaleId)
            .NotEmpty().WithMessage("SaleId is required.");

        RuleFor(sale => sale.SaleItems)
            .NotEmpty().WithMessage("At least one item is required.")
            .ForEach(item => item.SetValidator(new UpdateSaleItemRequestValidator()));
    }
}
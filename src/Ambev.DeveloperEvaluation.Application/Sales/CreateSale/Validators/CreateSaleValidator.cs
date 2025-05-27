using Ambev.DeveloperEvaluation.Application.Sales.CreateSale.Validators.Command;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale.Validators;

/// <summary>
/// Validator for CreateSaleRequest that defines validation rules for user creation.
/// </summary>
public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - SaleDate: Cannot be default
    /// - CustomerId: Must not be empty
    /// - BranchId: Must be greater than zero
    /// - Items: Must have at least one item, and each item must be valid
    /// </remarks>
    public CreateSaleValidator()
    {
        RuleFor(sale => sale.SaleDate)
            .NotEqual(default(DateTime)).WithMessage("SaleDate is required.");

        RuleFor(sale => sale.CustomerId)
            .NotEmpty().WithMessage("CustomerId is required.");

        RuleFor(sale => sale.BranchId)
            .GreaterThan(0).WithMessage("BranchId must be greater than zero.");

        RuleFor(sale => sale.SaleItems)
            .NotEmpty().WithMessage("At least one item is required.")
            .ForEach(item => item.SetValidator(new CreateSaleItemRequestValidator()));
    }
}
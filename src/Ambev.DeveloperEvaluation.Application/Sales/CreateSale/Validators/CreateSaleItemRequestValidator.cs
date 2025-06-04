using Ambev.DeveloperEvaluation.Application.Sales.CreateSale.Validators.Command;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale.Validators;

public class CreateSaleItemRequestValidator : AbstractValidator<CreateSaleItemCommand>
{
    public CreateSaleItemRequestValidator()
    {
        RuleFor(item => item.ProductId)
            .NotEmpty().WithMessage("ProductId is required.");

        RuleFor(item => item.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than zero.");

        RuleFor(item => item.UnitPrice)
            .GreaterThan(0).WithMessage("UnitPrice must be greater than zero.");
    }
}
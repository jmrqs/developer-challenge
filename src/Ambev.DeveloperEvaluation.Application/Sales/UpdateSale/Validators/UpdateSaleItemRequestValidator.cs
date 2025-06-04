using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.Validators;

public class UpdateSaleItemRequestValidator : AbstractValidator<UpdateSaleItemCommand>
{
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

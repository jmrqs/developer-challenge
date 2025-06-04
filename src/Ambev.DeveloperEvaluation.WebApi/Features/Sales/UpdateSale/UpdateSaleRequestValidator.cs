using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
{
    public UpdateSaleRequestValidator()
    {
        RuleFor(sale => sale.SaleId)
            .NotEmpty().WithMessage("SaleId is required.");

        RuleFor(sale => sale.SaleItems)
            .NotEmpty().WithMessage("At least one item is required.")
            .ForEach(item => item.SetValidator(new UpdateSaleItemRequestValidator()));
    }

    public class UpdateSaleItemRequestValidator : AbstractValidator<UpdateSaleItemRequest>
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
}
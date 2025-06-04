using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale.Validators.Command;

public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    public DateTime SaleDate { get; set; }
    public Guid CustomerId { get; set; }
    public int BranchId { get; set; }
    public List<CreateSaleItemCommand> SaleItems { get; set; } = [];

    public ValidationResultDetail Validate()
    {
        var validator = new CreateSaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
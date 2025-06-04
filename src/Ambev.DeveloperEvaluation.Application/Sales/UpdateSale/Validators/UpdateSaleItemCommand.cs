using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.Validators;

public class UpdateSaleItemCommand
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale.Validators.Command;

public class CreateSaleItemCommand
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
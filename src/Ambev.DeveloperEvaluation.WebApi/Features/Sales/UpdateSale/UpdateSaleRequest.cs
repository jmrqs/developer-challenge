using Ambev.DeveloperEvaluation.Common.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

public class UpdateSaleRequest
{
    public Guid SaleId { get; set; }
    public List<UpdateSaleItemRequest> SaleItems { get; set; } = [];
    public SaleStatus IsCancelled { get; set; }
}

public class UpdateSaleItemRequest
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
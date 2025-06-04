using Ambev.DeveloperEvaluation.Common.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

public class UpdateSaleResponse
{
    public Guid SaleId { get; set; }
    public DateTime SaleDate { get; set; }
    public Guid CustomerId { get; set; }
    public int BranchId { get; set; }
    public List<UpdateSaleItemResponse> SaleItems { get; set; } = [];
    public decimal TotalAmount { get; set; }
    public SaleStatus IsCancelled { get; set; }
}

public class UpdateSaleItemResponse
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
}
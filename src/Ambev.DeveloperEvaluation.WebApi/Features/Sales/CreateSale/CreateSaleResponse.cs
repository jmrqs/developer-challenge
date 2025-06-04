using Ambev.DeveloperEvaluation.Common.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleResponse
{
    public Guid SaleId { get; set; }
    public int SaleNumber { get; set; }
    public DateTime SaleDate { get; set; }
    public Guid CustomerId { get; set; }
    public int BranchId { get; set; }
    public List<CreateSaleItemResponse> SaleItems { get; set; } = [];
    public decimal TotalAmount { get; set; }
    public SaleStatus IsCancelled { get; set; }
}

public class CreateSaleItemResponse
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
}
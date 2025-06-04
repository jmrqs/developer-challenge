using Ambev.DeveloperEvaluation.Common.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSaleResponse
{
    public Guid Id { get; set; }
    public int SaleNumber { get; set; }
    public DateTime SaleDate { get; set; }
    public Guid CustomerId { get; set; }
    public int BranchId { get; set; }
    public List<GetSaleItemResponse> SaleItems { get; set; } = [];
    public decimal TotalAmount { get; set; }
    public SaleStatus IsCancelled { get; set; }
}
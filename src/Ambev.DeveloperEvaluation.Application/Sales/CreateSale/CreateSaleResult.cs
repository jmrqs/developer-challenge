using Ambev.DeveloperEvaluation.Common.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleResult
{
    public Guid Id { get; set; }
    public int SaleNumber { get; set; }
    public DateTime SaleDate { get; set; }
    public Guid CustomerId { get; set; }
    public int BranchId { get; set; }
    public List<CreateSaleItemResult> SaleItems { get; set; } = [];
    public decimal TotalAmount { get; set; }
    public SaleStatus IsCancelled { get; set; }
}
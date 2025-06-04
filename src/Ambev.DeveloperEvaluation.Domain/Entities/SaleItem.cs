using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Interfaces.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleItem : BaseEntity, ISaleItem
{
     public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
}
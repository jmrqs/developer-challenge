using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Interfaces.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents an item within a sale.
/// This entity follows domain-driven design principles and includes business rules for quantity and discounts.
/// </summary>
public class SaleItem : BaseEntity, ISaleItem
{
    /// <summary>
    /// Unique identifier of the product being sold.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Quantity of the product in this sale item.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Unit price of the product.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Discount applied to this sale item.
    /// </summary>
    public decimal Discount { get; set; }
}
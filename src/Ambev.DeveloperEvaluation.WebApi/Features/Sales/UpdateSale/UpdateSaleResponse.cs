using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Represents a request to create a new sale in the system.
/// </summary>
public class UpdateSaleResponse
{
    /// <summary>
    /// Gets or sets the sale id. Must be unique within the system.
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    /// Gets or sets the date when the sale was made.
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// Gets or sets the customer id associated with the sale.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the branch where the sale was made.
    /// </summary>
    public int BranchId { get; set; }

    /// <summary>
    /// Gets or sets the list of items in the sale.
    /// </summary>
    public List<UpdateSaleItemResponse> SaleItems { get; set; } = [];

    /// <summary>
    /// Gets or sets the total amount for the sale.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets or sets the sale status indicating whether the sale is cancelled or not.
    /// </summary>
    public SaleStatus IsCancelled { get; set; }
}

/// <summary>
/// Represents an item in a sale request to create a new sale in the system.
/// </summary>
public class UpdateSaleItemResponse
{
    /// <summary>
    /// Gets or sets the product identifier or name.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the product.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the unit price of the product.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the discount applied to this item.
    /// </summary>
    public decimal Discount { get; set; }
}
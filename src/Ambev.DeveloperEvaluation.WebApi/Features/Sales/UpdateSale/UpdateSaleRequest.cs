using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Represents a request to create a new sale in the system.
/// </summary>
public class UpdateSaleRequest
{
    /// <summary>
    /// Gets or sets the sale id. Must be unique within the system.
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    /// Gets or sets the list of items in the sale.
    /// </summary>
    public List<UpdateSaleItemRequest> SaleItems { get; set; } = [];

    /// <summary>
    /// Gets or sets the sale status indicating whether the sale is cancelled or not.
    /// </summary>
    public SaleStatus IsCancelled { get; set; }
}

/// <summary>
/// Represents an item in a sale request to update a new sale in the system.
/// </summary>
public class UpdateSaleItemRequest
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
}
namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale.Request;

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
namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Represents the response returned after successfully updating a new sale.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly updated sale,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class UpdateSaleItemResult
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
    /// Discounts applied to the product.
    /// </summary>
    public decimal Discount { get; set; }
}

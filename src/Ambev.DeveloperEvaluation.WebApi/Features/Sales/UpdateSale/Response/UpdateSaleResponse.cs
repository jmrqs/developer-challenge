using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale.Response;

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
    public List<UpdateSaleItemResponse> Items { get; set; } = [];

    /// <summary>
    /// Gets or sets the discounts for the sale.
    /// </summary>
    public decimal Discounts { get; set; }

    /// <summary>
    /// Gets or sets the total amount for the sale.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets or sets the sale status indicating whether the sale is cancelled or not.
    /// </summary>
    public SaleStatus IsCancelled { get; set; }
}
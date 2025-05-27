using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale.Request;

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
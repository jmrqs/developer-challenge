using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Represents the response returned after successfully updating a new sale.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly updated sale,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class UpdateSaleResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly updated sale.
    /// </summary>
    /// <value>A GUID that uniquely identifies the updated sale in the system.</value>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the sale id. Must be unique within the system.
    /// </summary>
    public int SaleNumber { get; set; }

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
    public List<UpdateSaleItemResult> SaleItems { get; set; } = [];

    /// <summary>
    /// Total amount of the sale.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Current status of the sale (e.g., Cancelled, NotCancelled).
    /// </summary>
    public SaleStatus IsCancelled { get; set; }
}

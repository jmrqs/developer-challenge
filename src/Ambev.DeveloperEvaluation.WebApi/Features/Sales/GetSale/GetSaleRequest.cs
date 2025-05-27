namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

/// <summary>
/// Request model for getting a sale by ID
/// </summary>
public class GetSaleRequest
{
    /// <summary>
    /// Gets or sets the current page number for pagination.
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// Gets or sets the number of items to be returned per page.
    /// </summary>
    public int PageSize { get; set; }
}

using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Command for retrieving a user by their ID
/// </summary>
public record GetSaleCommand : IRequest<List<GetSaleResult>>
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

using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public record GetSaleCommand : IRequest<List<GetSaleResult>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
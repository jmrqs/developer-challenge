using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSaleProfile : Profile
{
    public GetSaleProfile()
    {
        CreateMap<GetSaleRequest, GetSaleCommand>();
        CreateMap<GetSaleResult, GetSaleResponse>();
    }
}
public class GetSaleItemProfile : Profile
{
    public GetSaleItemProfile()
    {
        CreateMap<GetSaleItemResult, GetSaleItemResponse>();
    }
}
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale.Validators.Command;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleRequest, CreateSaleCommand>();
        CreateMap<CreateSaleCommand, Sale>();
        CreateMap<CreateSaleResult, CreateSaleResponse>()
          .ForMember(m => m.SaleId, opt => opt.MapFrom(x => x.Id));

        CreateMap<CreateSaleItemRequest, CreateSaleItemCommand>();
        CreateMap<CreateSaleItemCommand, SaleItem>();
        CreateMap<CreateSaleItemResult, CreateSaleItemResponse>();
    }
}
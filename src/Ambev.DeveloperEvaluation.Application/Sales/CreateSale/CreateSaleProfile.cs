using Ambev.DeveloperEvaluation.Application.Sales.CreateSale.Validators.Command;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        CreateMap<Sale, CreateSaleResult>();
    }

    public class CreateSaleItemProfile : Profile
    {
        public CreateSaleItemProfile()
        {
            CreateMap<SaleItem, CreateSaleItemCommand>();
            CreateMap<SaleItem, CreateSaleItemResult>();
        }
    }
}
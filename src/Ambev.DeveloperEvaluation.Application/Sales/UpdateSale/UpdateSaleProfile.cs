using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.Validators;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
public class UpdateSaleProfile : Profile
{
    public UpdateSaleProfile()
    {
        CreateMap<UpdateSaleCommand, Sale>().ForMember(m => m.IsCancelled, opt => opt.MapFrom(x => (int)x.IsCancelled));
        CreateMap<Sale, UpdateSaleResult>().ForMember(m => m.IsCancelled, opt => opt.MapFrom(x => (int)x.IsCancelled));

        CreateMap<UpdateSaleItemCommand, SaleItem>();
        CreateMap<SaleItem, UpdateSaleItemResult>();
    }
}

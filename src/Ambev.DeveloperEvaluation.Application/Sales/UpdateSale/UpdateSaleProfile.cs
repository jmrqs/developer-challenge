using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale.Validators.Command;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.Validators;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Profile for mapping between Sale entity and UpdateSaleResponse
/// </summary>
public class UpdateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateSale operation
    /// </summary>
    public UpdateSaleProfile()
    {
        CreateMap<UpdateSaleCommand, Sale>().ForMember(m => m.IsCancelled, opt => opt.MapFrom(x => (int)x.IsCancelled));
        CreateMap<Sale, UpdateSaleResult>().ForMember(m => m.IsCancelled, opt => opt.MapFrom(x => (int)x.IsCancelled));

        CreateMap<UpdateSaleItemCommand, SaleItem>();
        CreateMap<SaleItem, UpdateSaleItemResult>();
    }
}

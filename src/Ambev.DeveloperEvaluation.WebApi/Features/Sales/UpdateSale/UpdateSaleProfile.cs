using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.Validators;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale.Request;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale.Response;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Profile for mapping between Application and API UpdateSale responses
/// </summary>
public class UpdateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateSale feature
    /// </summary>
    public UpdateSaleProfile()
    {
        CreateMap<UpdateSaleRequest, UpdateSaleCommand>();
        CreateMap<UpdateSaleResult, UpdateSaleResponse>();
        CreateMap<Sale, UpdateSaleResult>();
    }

    /// <summary>
    /// Initializes the mappings for UpdateItemSale feature
    /// </summary>
    public class UpdateItemSale : Profile
    {
        public UpdateItemSale()
        {
            CreateMap<UpdateSaleItemRequest, UpdateSaleItemCommand>();
        }
    }
}

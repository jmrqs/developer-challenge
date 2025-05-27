using Ambev.DeveloperEvaluation.Application.Sales.CreateSale.Validators.Command;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Profile for mapping between Sale entity and CreateSaleResponse
/// </summary>
public class CreateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSale operation
    /// </summary>
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

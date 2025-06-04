using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.Validators;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Interfaces.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        var result = new UpdateSaleResult();
        var validator = new UpdateSaleValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var saleDb = await _saleRepository.GetByIdAsync(command.SaleId, cancellationToken);

        if (saleDb != null)
        {
            foreach (var saleItem in command.SaleItems)
            {
                var itemDb = saleDb.SaleItems.FirstOrDefault(x => x.ProductId == saleItem.ProductId);

                if (itemDb is null)
                {
                    saleDb.SaleItems.Add(new SaleItem
                    {
                        ProductId = saleItem.ProductId,
                        Quantity = saleItem.Quantity,
                        UnitPrice = saleItem.UnitPrice
                    });
                }
                else
                {
                    itemDb.Quantity = saleItem.Quantity;
                    itemDb.UnitPrice = saleItem.UnitPrice;
                }

                Sale.Update(saleDb);

                await _saleRepository.UpdateAsync(saleDb, cancellationToken);
            }

            var itemsDbToRemove = saleDb.SaleItems.Where(itemDb => command.SaleItems.All(c => c.ProductId != itemDb.ProductId)).ToList();

            foreach (var itemDbToRemove in itemsDbToRemove)
            {
                await _saleRepository.DeleteItemAsync(saleDb.Id, itemDbToRemove.ProductId, cancellationToken);
                saleDb.SaleItems.Remove(itemDbToRemove);
            }

            var updatedSale = await _saleRepository.UpdateAsync(saleDb, cancellationToken);
            result = _mapper.Map<UpdateSaleResult>(updatedSale);
        }

        return result;
    }
}
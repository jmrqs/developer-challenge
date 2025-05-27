using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.Validators;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Interfaces.Entities;
using Ambev.DeveloperEvaluation.Domain.Interfaces.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using System.Linq;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Handler for processing UpdateSaleCommand requests
/// </summary>
public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;

    /// <summary>
    /// Initializes a new instance of UpdateSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for UpdateSaleCommand</param>
    public UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper, IPasswordHasher passwordHasher)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    /// <summary>
    /// Handles the UpdateSaleCommand request
    /// </summary>
    /// <param name="command">The UpdateSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale details</returns>
    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateSaleValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        // Send by event
        //_bus.Publish(new SaleModifiedEvent(new SaleModified(sale));

        // This can be consumed asynchronously by microservices (consumer) to persist in a repository.
        // Alternatively, without messaging, it can be saved directly to the repository like:

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
        }

        var result = _mapper.Map<UpdateSaleResult>(saleDb);
        return result;
    }
}
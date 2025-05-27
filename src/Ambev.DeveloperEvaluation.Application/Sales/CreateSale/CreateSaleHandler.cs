using Ambev.DeveloperEvaluation.Application.Sales.CreateSale.Validators;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale.Validators.Command;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Interfaces.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Handler for processing CreateSaleCommand requests
/// </summary>
public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;

    /// <summary>
    /// Initializes a new instance of CreateSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateSaleCommand</param>
    public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper, IPasswordHasher passwordHasher)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    /// <summary>
    /// Handles the CreateSaleCommand request
    /// </summary>
    /// <param name="command">The CreateSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale details</returns>
    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sales = Sale.Create(_mapper.Map<Sale>(command));

        // Send by event

        // Config. simplified:

        // CreateSaleHandler
        // readonly IBus _bus;
        // _bus.Publish(new SaleCreatedEvent(new SaleCreated(sales));

        // Program.cs (Best practice: extract this into an extension method to be consumed by the Program.cs)
        // RabbitMQ, for example:
        // var queueName = "queue-name";
        // services.AddRebus(c => c.Transport(t => t.UseRabbitMq(Configuration.GetConnectionString("RabbitConnection"), queueName)));
        // services.AutoRegisterHandlersFromAssemblyOf<CreateSaleHandler>();
        // app.ApplicationServices.UseRebus(c =>
        // {
        //    c.Subscribe<SaleCreatedEvent>().Wait();
        // });

        // This can be consumed asynchronously by microservices (via a consumer) to persist in a repository.
        // Alternatively, without messaging, it can be saved directly to the repository like:

        var createdSale = await _saleRepository.CreateAsync(sales, cancellationToken);
        var result = _mapper.Map<CreateSaleResult>(createdSale);
        return result;
    }
}
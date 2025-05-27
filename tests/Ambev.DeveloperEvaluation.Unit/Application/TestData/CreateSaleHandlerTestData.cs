using Ambev.DeveloperEvaluation.Application.Sales.CreateSale.Validators.Command;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class CreateSaleHandlerTestData
{
    /// <summary>
    /// Configures the Faker to generate valid CreateSaleCommand instances.
    /// The generated sales will include:
    /// - SaleId (random Guid)
    /// - SaleDate (a recent date within the last 30 days)
    /// - CustomerId (random Guid)
    /// - BranchId (random integer between 1 and 100)
    /// - SaleItems (a list containing between 1 and 10 valid sale items)
    /// </summary>
    private static readonly Faker<CreateSaleCommand> createSaleHandlerFaker = new Faker<CreateSaleCommand>()
        .RuleFor(u => u.SaleDate, f => f.Date.Recent(30))
        .RuleFor(u => u.CustomerId, Guid.NewGuid())
        .RuleFor(u => u.BranchId, f => f.Random.Number(1, 100))
        .RuleFor(u => u.SaleItems, saleItemsFaker.GenerateBetween(1, 10));

    /// <summary>
    /// Configures the Faker to generate valid CreateSaleItemCommand instances.
    /// Each item includes:
    /// - ProductId (random Guid)
    /// - Quantity (integer between 1 and 20)
    /// - UnitPrice (decimal between 10.00 and 500.00, rounded to two decimal places)
    /// </summary>
    private static readonly Faker<CreateSaleItemCommand> saleItemsFaker = new Faker<CreateSaleItemCommand>()
        .RuleFor(i => i.ProductId, Guid.NewGuid())
        .RuleFor(i => i.Quantity, f => f.Random.Number(1, 20))
        .RuleFor(i => i.UnitPrice, f => Math.Round(f.Random.Decimal(10, 500), 2));

    /// <summary>
    /// Generates a valid Sale entity with randomized data.
    /// The generated sale will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Sale entity with randomly generated data.</returns>
    public static CreateSaleCommand GenerateValidCommand()
    {
        return createSaleHandlerFaker.Generate();
    }
}

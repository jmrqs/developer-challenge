using Ambev.DeveloperEvaluation.Common.Enums;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Interfaces.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a sale in the system with all information.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Sale : BaseEntity, ISale
{
    /// <summary>
    /// Gets or sets the sale id. Must be unique within the system.
    /// </summary>
    public int SaleNumber { get; set; }

    /// <summary>
    /// Date when the sale was made.
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// Unique identifier of the customer who made the purchase.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Unique identifier of the branch where the sale was made.
    /// </summary>
    public int BranchId { get; set; }

    /// <summary>
    /// List of items involved in the sale.
    /// </summary>
    public List<SaleItem> SaleItems { get; set; } = [];

    /// <summary>
    /// Total amount of the sale.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Current status of the sale (e.g., Cancelled, NotCancelled).
    /// </summary>
    public SaleStatus IsCancelled { get; set; }

    /// <summary>
    /// Factory method to create a new sale, applying all business rules,
    /// default statuses, discounts, and total calculations.
    /// </summary>
    /// <param name="sale">The sale entity to be created.</param>
    /// <returns>A fully prepared sale instance.</returns>
    public static Sale Create(Sale sale)
    {
        ArgumentNullException.ThrowIfNull(sale);

        sale.IsCancelled = SaleStatus.NotCancelled;

        sale.ApplyDiscounts();

        sale.CalculateTotalAmount();

        return sale;
    }

    public static Sale Update(Sale sale)
    {
        ArgumentNullException.ThrowIfNull(sale);

        sale.IsCancelled = SaleStatus.NotCancelled;

        sale.ApplyDiscounts();

        sale.CalculateTotalAmount();

        return sale;
    }

    /// <summary>
    /// Calculate sale total amount.
    /// </summary>
    /// <returns></returns>
    private void CalculateTotalAmount()
    {
        TotalAmount = SaleItems.Sum(item =>
            (item.UnitPrice * item.Quantity) - item.Discount);
    }

    /// <summary>
    /// Applies discount rules to all sale items.
    /// </summary>
    private void ApplyDiscounts()
    {
        List<IDiscountStrategy> strategies =
        [
            new NoDiscountStrategy(),
            new TenPercentDiscountStrategy(),
            new TwentyPercentDiscountStrategy()
         ];

        foreach (var item in SaleItems)
        {
            QuantitySpecification.ValidateMaximum(item);

            foreach (var s in strategies)
            {
                if (s.IsApplicable(item))
                    item.Discount = s.CalculateDiscount(item);
            }
        }
    }

    public static class QuantitySpecification
    {
        public static void ValidateMaximum(SaleItem item)
        {
            if (item.Quantity > 20)
                throw new InvalidOperationException(
                    "It is not possible to sell more than 20 identical items.");
        }
    }

    public interface IDiscountStrategy
    {
        bool IsApplicable(SaleItem item);
        decimal CalculateDiscount(SaleItem item);
    }

    public class NoDiscountStrategy : IDiscountStrategy
    {
        public bool IsApplicable(SaleItem item) => item.Quantity < 4;

        public decimal CalculateDiscount(SaleItem item) => 0m;
    }

    public class TenPercentDiscountStrategy : IDiscountStrategy
    {
        public bool IsApplicable(SaleItem item) => item.Quantity >= 4 && item.Quantity < 10;

        public decimal CalculateDiscount(SaleItem item) =>
            item.UnitPrice * item.Quantity * 0.10m;
    }

    public class TwentyPercentDiscountStrategy : IDiscountStrategy
    {
        public bool IsApplicable(SaleItem item) => item.Quantity >= 10 && item.Quantity <= 20;

        public decimal CalculateDiscount(SaleItem item) =>
            item.UnitPrice * item.Quantity * 0.20m;
    }
}
using Ambev.DeveloperEvaluation.Common.Enums;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Interfaces.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Entities;
public class Sale : BaseEntity, ISale
{
    public int SaleNumber { get; set; }
    public DateTime SaleDate { get; set; }
    public Guid CustomerId { get; set; }
    public int BranchId { get; set; }
    public List<SaleItem> SaleItems { get; set; } = [];
    public decimal TotalAmount { get; set; }
    public SaleStatus IsCancelled { get; set; }
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

    private void CalculateTotalAmount()
    {
        TotalAmount = SaleItems.Sum(item =>
            (item.UnitPrice * item.Quantity) - item.Discount);
    }

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
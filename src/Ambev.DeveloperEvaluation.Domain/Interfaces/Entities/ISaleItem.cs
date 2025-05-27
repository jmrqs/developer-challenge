namespace Ambev.DeveloperEvaluation.Domain.Interfaces.Entities
{
    /// <summary>
    /// Defines the contract for representing a sale item in the system.
    /// </summary>
    public interface ISaleItem
    {
        /// <summary>
        /// Unique identifier of the product being sold.
        /// </summary>
        Guid ProductId { get; set; }

        /// <summary>
        /// Quantity of the product included in the sale.
        /// </summary>
        int Quantity { get; set; }

        /// <summary>
        /// Unit price of the product at the time of the sale.
        /// </summary>
        decimal UnitPrice { get; set; }

        /// <summary>
        /// Discounts applied to the product.
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Calculate product discounts.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public decimal CalculateDiscounts()
        {
            if (Quantity > 20)
                throw new InvalidOperationException("It is not possible to sell more than 20 identical items.");

            if (Quantity < 4)
                return 0m;

            decimal discountPercentage = 0m;

            if (Quantity >= 4 && Quantity < 10)
                discountPercentage = 0.10m;
            else if (Quantity >= 10 && Quantity <= 20)
                discountPercentage = 0.20m;

            var discount = UnitPrice * Quantity * discountPercentage;
            Discount = discount;
            return discount;
        }
    }
}
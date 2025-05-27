using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Interfaces.Entities
{
    /// <summary>
    /// Defines the contract for representing a sale in the system.
    /// </summary>
    public interface ISale
    {
        /// <summary>
        /// Date when the sale was made.
        /// </summary>
        public DateTime SaleDate { get; }

        /// <summary>
        /// Customer who made the purchase.
        /// </summary>
        public Guid CustomerId { get; }

        /// <summary>
        /// Branch where the sale was made.
        /// </summary>
        public int BranchId { get; }

        // <summary>
        /// List of products in the sale.
        /// </summary>
        public List<SaleItem> SaleItems { get; }

        /// <summary>
        /// Total amount of the sale.
        /// </summary>
        public decimal TotalAmount { get; }

        /// <summary>
        /// Indicates whether the sale is cancelled or not.
        /// </summary>
        public SaleStatus IsCancelled { get; }
    }
}

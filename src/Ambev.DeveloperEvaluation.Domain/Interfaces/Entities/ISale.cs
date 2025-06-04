using Ambev.DeveloperEvaluation.Common.Enums;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Interfaces.Entities
{
    public interface ISale
    {
        public DateTime SaleDate { get; }
        public Guid CustomerId { get; }
        public int BranchId { get; }
        public List<SaleItem> SaleItems { get; }
        public decimal TotalAmount { get; }
        public SaleStatus IsCancelled { get; }
    }
}
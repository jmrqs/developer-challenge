using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Interfaces.Repositories;

public interface ISaleRepository
{
    Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default);
    Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Sale>> GetAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
    Task<Sale?> UpdateAsync(Sale sale, CancellationToken cancellationToken = default);
    Task<bool> DeleteItemAsync(Guid saleId, Guid productId, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
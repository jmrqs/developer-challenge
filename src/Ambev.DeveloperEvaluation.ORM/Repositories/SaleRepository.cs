using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ISaleRepository using Entity Framework Core
/// </summary>
public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of SaleRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new sale in the database
    /// </summary>
    /// <param name="sale">The sale to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale</returns>
    public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        var response = await _context.Sales.AddAsync(sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return response.Entity;
    }

    /// <summary>
    /// Retrieves a sale by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale if found, null otherwise</returns>
    public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Sales.Include(m => m.SaleItems).FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    /// <summary>
    /// Retrieves a sale by page number and page size
    /// </summary>
    /// <param name="id">The unique identifier of the sale</param>
    /// <param name="id">The unique identifier of the sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale if found, null otherwise</returns>
    public async Task<List<Sale>> GetAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
    {
        return await _context.Sales
                      .AsNoTracking()
                      .Include(m => m.SaleItems)
                      .OrderByDescending(p => p.SaleNumber)
                      .Skip((pageNumber - 1) * pageSize)
                      .Take(pageSize)
                      .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Updates an existing sale in the database.
    /// </summary>
    /// <param name="sale">The sale entity to update.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>The updated sale entity.</returns>
    public async Task<Sale?> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);

        return sale;
    }

    /// <summary>
    /// Deletes sale item from the database
    /// </summary>
    /// <param name="saleId">The unique identifier of the sale item to delete</param>
    /// <param name="productId">The unique identifier of the product item to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the sale was deleted, false if not found</returns>
    public async Task<bool> DeleteItemAsync(Guid saleId, Guid productId, CancellationToken cancellationToken = default)
    {
        var sale = await GetByIdAsync(saleId, cancellationToken);
        if (sale == null)
            return false;

        var itemsToRemove = sale.SaleItems.Where(m => m.ProductId == productId);
        _context.RemoveRange(itemsToRemove);

        _context.Sales.Update(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Deletes a sale from the database
    /// </summary>
    /// <param name="id">The unique identifier of the sale to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the sale was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var sale = await GetByIdAsync(id, cancellationToken);
        if (sale == null)
            return false;

        // Virtual deletation (best practices)
        //sale.IsCancelled = SaleStatus.Cancelled;
        //_context.Sales.Update(sale);
        // or..

        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}

using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;

    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        var response = await _context.Sales.AddAsync(sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return response.Entity;
    }

    public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Sales.Include(m => m.SaleItems).FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

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

    public async Task<Sale?> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);

        return sale;
    }

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

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var sale = await GetByIdAsync(id, cancellationToken);
        if (sale == null)
            return false;

        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}

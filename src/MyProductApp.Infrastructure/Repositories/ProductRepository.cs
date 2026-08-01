using Microsoft.EntityFrameworkCore;
using MyProductApp.Application.Interfaces.Repositories;
using MyProductApp.Domain.Entities;
using MyProductApp.Infrastructure.Persistence;

namespace MyProductApp.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _db;

    public ProductRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(Product product, CancellationToken ct = default)
    {
        await _db.Products.AddAsync(product, ct);
        await _db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Product product, CancellationToken ct = default)
    {
        _db.Products.Remove(product);
        await _db.SaveChangesAsync(ct);
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _db.Products.FindAsync(id, ct); 
    }

    public async Task<List<Product>> ListAsync(CancellationToken ct = default)
    {
        return await _db.Products.AsNoTracking().ToListAsync(ct);
    }

    public async Task UpdateAsync(Product product, CancellationToken ct = default)
    {
        _db.Products.Update(product);
        await _db.SaveChangesAsync(ct);
    }
}
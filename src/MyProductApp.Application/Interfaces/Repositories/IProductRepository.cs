using MyProductApp.Domain.Entities;

namespace MyProductApp.Application.Interfaces.Repositories;

public interface IPoductRepository
{
    Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task AddAsync(Product product, CancellationToken ct = default);
    Task UpdateAsync(Product product, CancellationToken ct = default);
    Task DeleteAsync(Product product, CancellationToken ct = default);
    Task<List<Product>> ListAsync(CancellationToken ct = default);
}
using ControleDeDespesas.Domain.Models;

namespace ControleDeDespesas.Domain.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<Category> GetByIdAsync(Guid id);
    Task<(IEnumerable<Category> Items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize);
    Task<Category> GetByNameAsync(string name);
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(Guid id);
}
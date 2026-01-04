using ControleDeDespesas.Domain.Models;

namespace ControleDeDespesas.Domain.Services;

public interface ICategoryService
{
    Task AddAsync(Category category);
    Task<Category> GetByIdAsync(Guid id);
    Task<(IEnumerable<Category> Items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize);
    Task<Category> GetByNameAsync(string name);
    Task UpdateAsync(Category category);
    Task DeleteAsync(Guid id);
}
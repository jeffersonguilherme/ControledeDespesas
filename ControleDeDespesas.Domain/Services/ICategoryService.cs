using ControleDeDespesas.Domain.Models;

namespace ControleDeDespesas.Domain.Services;

public interface ICategoryService
{
    Task AssAsync(Category category);
    Task<Category> GetByIdAsync(Guid id);
    Task<IEnumerable<Category>> GetAllAsync();
    Task UpdateAsync(Category category);
    Task DeleteAsync(Guid id);
}
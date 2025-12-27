using ControleDeDespesas.Domain.Models;

namespace ControleDeDespesas.Domain.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<Category> GetByIdAsync(Guid id);
    Task<IEnumerable<Category>> GetAllAsync();
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task Delete(Guid id);
}
using ControleDeDespesas.Domain.Models;
using ControleDeDespesas.Domain.Repositories.Interfaces;

namespace ControleDeDespesas.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public Task AddAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Category category)
    {
        throw new NotImplementedException();
    }
}
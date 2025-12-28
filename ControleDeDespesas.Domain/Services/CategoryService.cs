using ControleDeDespesas.Domain.Models;
using ControleDeDespesas.Domain.Repositories.Interfaces;

namespace ControleDeDespesas.Domain.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task AssAsync(Category category)
    {
        var existing = await _repository.GetByNameAsync(category.Name);
        if(existing != null)
            throw new InvalidOperationException("Já existe uma categoria com esse nome.");

        await _repository.AddAsync(category);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Category> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Category category)
    {
        await _repository.UpdateAsync(category);
    }
}
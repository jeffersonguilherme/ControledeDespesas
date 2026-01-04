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

    public async Task AddAsync(Category category)
    {
        var existing = await _repository.GetByNameAsync(category.Name);
        if(existing != null)
            throw new InvalidOperationException("Já existe uma categoria com esse nome.");

        await _repository.AddAsync(category);
    }

    public async Task DeleteAsync(Guid id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if(existing == null)
            throw new InvalidOperationException("Categoria não encontrada");

        await _repository.DeleteAsync(id);
    }

    public async Task<(IEnumerable<Category> Items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize)
    {
        return await _repository.GetAllAsync(pageNumber, pageSize);
    }

    public async Task<Category> GetByIdAsync(Guid id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if(existing == null)
            throw new InvalidOperationException("Categoria não encontrada");
        
        return existing;
    }

    public async Task<Category> GetByNameAsync(string name)
    {
        var existing = await _repository.GetByNameAsync(name);
        if(existing == null)
            throw new InvalidOperationException("Categoria não encontrada");
        return existing;
    }

    public async Task UpdateAsync(Category category)
    {
        var existing = await _repository.GetByIdAsync(category.Id);
        if(existing == null)
            throw new InvalidOperationException("Categoria não encontrada");
            
        await _repository.UpdateAsync(category);
    }
}
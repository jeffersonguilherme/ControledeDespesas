using ControleDeDespesas.Domain.Models;
using ControleDeDespesas.Domain.Repositories.Interfaces;

namespace ControleDeDespesas.Domain.Services;

public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _repository;

    public ExpenseService(IExpenseRepository repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(Expense expense)
    {
        if(expense.Amount <= 0)
            throw new ArgumentException("O valor da despesa deve ser maior que 0");
        
        await _repository.AddAsync(expense);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Expense>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<IEnumerable<Expense>> GetByCategoryAsync(Guid categoryId)
    {
        return await _repository.GetByCategoryAsync(categoryId);
    }

    public async Task<Expense> GetByIdAsyn(Guid id)
    {
       return await _repository.GetByIdAsync(id);
    }

    public async Task<decimal> GetTotalExpenseAsync(DateTime startDate, DateTime endDate)
    {
        var expenses = await _repository.GetAllAsync();
        decimal total = 0;
        foreach(var exp in expenses)
        {
            if(exp.Date >= startDate && exp.Date <= endDate)
            total += exp.Amount;
        }
        return total;
    }

    public async Task UpdateAsync(Expense expense)
    {
        await _repository.UpdateAsync(expense);
    }
}
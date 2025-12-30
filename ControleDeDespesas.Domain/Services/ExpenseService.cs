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

    public async Task<(IEnumerable<Expense> Items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize)
    {
        return await _repository.GetAllAsync(pageNumber, pageSize);
    }

    public async Task<(IEnumerable<Expense> Items, int TotalItems)> GetByCategoryAsync(Guid categoryId, int pageNumber, int pageSize)
    {
        return await _repository.GetByCategoryAsync(categoryId, pageNumber, pageSize);
    }

    public async Task<Expense> GetByIdAsyn(Guid id)
    {
       return await _repository.GetByIdAsync(id);
    }

    public Task<(IEnumerable<Expense> Items, int TotalItems)> GetByPaymentMethodAsync(Guid paymentId, int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public async Task<decimal> GetTotalExpenseAsync(DateTime startDate, DateTime endDate)
    {
        if (startDate > endDate)
            throw new ArgumentException("Data inicial não pode ser maior que a data final");

        return await _repository.GetTotalExpenseAsync(startDate, endDate);
    }

    public async Task UpdateAsync(Expense expense)
    {
        await _repository.UpdateAsync(expense);
    }
}
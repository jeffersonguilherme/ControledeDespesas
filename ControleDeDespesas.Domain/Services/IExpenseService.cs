using ControleDeDespesas.Domain.Models;

namespace ControleDeDespesas.Domain.Services;

public interface IExpenseService
{
    Task<Expense> GetByIdAsyn(Guid id);
    Task<IEnumerable<Expense>> GetAllAsync();
    Task AddAsync(Expense expense);
    Task UpdateAsync(Expense expense);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Expense>> GetByCategoryAsync(Guid categoryId);
    Task<decimal> GetTotalExpenseAsync(DateTime startDate, DateTime endDate);
}
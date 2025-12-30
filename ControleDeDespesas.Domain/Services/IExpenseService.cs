using ControleDeDespesas.Domain.Models;

namespace ControleDeDespesas.Domain.Services;

public interface IExpenseService
{
    Task<Expense> GetByIdAsyn(Guid id);
    Task<(IEnumerable<Expense> Items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize);
    Task AddAsync(Expense expense);
    Task UpdateAsync(Expense expense);
    Task DeleteAsync(Guid id);
    Task<(IEnumerable<Expense> Items, int TotalItems)> GetByCategoryAsync(Guid categoryId, int pageNumber, int pageSize);
    Task<(IEnumerable<Expense> Items, int TotalItems)> GetByPaymentMethodAsync(Guid paymentId, int pageNumber, int pageSize); 
    Task<decimal> GetTotalExpenseAsync(DateTime startDate, DateTime endDate);
}
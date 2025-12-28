using ControleDeDespesas.Application.DTOs.Expense;
using ControleDeDespesas.Application.Responses;

namespace ControleDeDespesas.Application.Interfaces;

public interface IExpenseAppService
{
    Task<ResponseModel<ExpenseResponseDto>> AddExpenseAsync(ExpenseCreateDto expenseCreateDto);
    Task<PagedResponse<ExpenseResponseDto>> GetAllExpenseAsync(int pageNumber, int pageSize);
    Task<ResponseModel<ExpenseResponseDto>> GetByIdExpenseAsync(Guid id);
    Task<PagedResponse<ExpenseResponseDto>> GetByCategoryExpenseAsync(Guid id, int pageNumber, int pageSize);
    Task<ResponseModel<ExpenseUpdateDto>> UpdateExpenseAsync(Guid id, ExpenseUpdateDto expenseUpdateDto);
    Task<ResponseModel<bool>> DeleteExpenseAsync(Guid id);
}
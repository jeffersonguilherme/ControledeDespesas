using ControleDeDespesas.Domain.Models;

namespace ControleDeDespesas.Domain.Repositories.Interfaces;

public interface IExpenseRepository
{
    Task<Expense> GetByIdAsync(Guid id); // Busca despesa por id
    Task<(IEnumerable<Expense> Items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize); //Lista todas as despesas
    Task AddAsync(Expense expense); //Adicionar uma nova despesa
    Task UpdateAsync(Expense expense); //Atualizar despesa existente
    Task DeleteAsync(Guid id); // Remove despesa
    Task<(IEnumerable<Expense> Items, int TotalItems)> GetByCategoryAsync(Guid categoryId, int pageNumber, int pageSize); //Consulta espercíficas por categorias
    Task<(IEnumerable<Expense> Items, int TotalItems)> GetByPaymentMethodAsync(Guid paymentId, int pageNumber, int pageSize); //COnultado todas as despensa por metodo de pagamento
    Task<decimal> GetTotalExpenseAsync(DateTime startDate, DateTime endDate);

}
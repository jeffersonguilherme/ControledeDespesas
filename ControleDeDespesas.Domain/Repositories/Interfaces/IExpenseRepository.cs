using ControleDeDespesas.Domain.Models;

namespace ControleDeDespesas.Domain.Repositories.Interfaces;

public interface IExpenseRepository
{
    Task<Expense> GetByIdAsync(Guid id); // Busca despesa por id
    Task<IEnumerable<Expense>> GetAllAsync(); //Lista todas as despesas
    Task AddAsync(Expense expense); //Adicionar uma nova despesa
    Task UpdateAsync(Expense expense); //Atualizar despesa existente
    Task DeleteAsync(Guid id); // Remove despesa
    Task<IEnumerable<Expense>> GetByCategoryAsync(Guid categoryId); //Consulta espercíficas por categorias
}
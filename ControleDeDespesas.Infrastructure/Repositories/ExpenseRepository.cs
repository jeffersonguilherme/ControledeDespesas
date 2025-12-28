using ControleDeDespesas.Domain.Models;
using ControleDeDespesas.Domain.Repositories.Interfaces;
using ControleDeDespesas.Infrastructure.Data;
using Dapper;

namespace ControleDeDespesas.Infrastructure.Repositories;

public class ExpenseRepository : IExpenseRepository
{
    private readonly DapperContext _context;

    public ExpenseRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Expense expense)
    {
        const string sql = @"INSERT INTO Expense (
                            Id,
                            Description,
                            Amount,
                            Date,
                            CategoryId,
                            PaymentMethodId,
                            IsRecurring,
                            IsPaid
                            )
                            VALUES(
                            @Id,
                            @Description,
                            @Amount,
                            @Date,
                            @CategoryId,
                            @PaymentMethodId,
                            @IsRecurring,
                            @IsPaid)";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new
        {
           expense.Id,
           expense.Description,
           expense.Amount,
           expense.Date,
           expense.CategoryId,
           expense.PaymentMethodId,
           expense.IsRecurring,
           expense.IsPaid 
        });
    }

    public async Task DeleteAsync(Guid id)
    {
       const string sql = @"DELETE FROM Expense WHERE Id = @Id";

       using var connection = _context.CreateConnection();
       await connection.ExecuteAsync(sql, new{Id = id});
    }

    public async Task<IEnumerable<Expense>> GetAllAsync()
    {
        const string sql = @"SELECT * FROM EXPENSE";

        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Expense>(sql);
    }

    public async Task<IEnumerable<Expense>> GetByCategoryAsync(Guid categoryId)
    {
        const string sql = @"SELECT * FROM Expense WHERE CategoryId = @CategoryId";

        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Expense>(sql, new{CategoryId = categoryId});
    }

    public async Task<Expense> GetByIdAsync(Guid id)
    {
        const string sql = @"SELECT * FROM Expense WHERE Id = @Id";

        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Expense>(sql, new {Id = id});
    }

    public async Task UpdateAsync(Expense expense)
    {
        const string sql = @"UPDATE Expense SET 
                            Description = @Description,
                            Amount = @Amount,
                            Date = @Date,
                            CategoryId = @CategoryId,
                            PaymentMethodId = @PaymentMethodId,
                            IsRecurring = @IsRecurring,
                            IsPaid = @IsPaid
                            WHERE Id = @Id";
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new
        {
           expense.Id,
           expense.Description,
           expense.Amount,
           expense.Date,
           expense.CategoryId,
           expense.PaymentMethodId,
           expense.IsRecurring,
           expense.IsPaid
        });
    }
}
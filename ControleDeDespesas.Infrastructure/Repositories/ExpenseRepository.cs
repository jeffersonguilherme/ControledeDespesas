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

    public async Task<(IEnumerable<Expense> Items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize)
    {
        const string sql = @"SELECT * FROM Expense ORDER BY Date OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY";
        var countSql = @"SELECT COUNT(Id) FROM Expense";

        var paramtersPaged = new
        {
            Skip = (pageNumber - 1) * pageSize,
            Take = pageSize
        };

        using var connection = _context.CreateConnection();
        using var multiConsults = await connection.QueryMultipleAsync($"{countSql};{sql}", paramtersPaged);

        var totalItems = await multiConsults.ReadFirstAsync<int>();
        var expenses = await multiConsults.ReadAsync<Expense>();
        return (expenses, totalItems);
    }

    public async Task<(IEnumerable<Expense> Items, int TotalItems)> GetByCategoryAsync(Guid categoryId, int pageNumber, int pageSize)
    {
        const string sql = @"SELECT * FROM Expense WHERE CategoryId = @CategoryId ORDER BY Date DESC OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY";
        var countSql = @"SELECT COUNT(CategoryId) FROM Expense WHERE CategoryId = @CategoryId";

        var paramtersPaged = new
        {
            Skip = (pageNumber -1) * pageSize,
            Take = pageSize,
            CategoryId = categoryId
        };

        using var connection = _context.CreateConnection();
        using var multi = await connection.QueryMultipleAsync($"{countSql};{sql}", paramtersPaged);

        var totalItems = await multi.ReadFirstAsync<int>();
        var expenses = await multi.ReadAsync<Expense>();

        return (expenses, totalItems);
    }

    public async Task<Expense> GetByIdAsync(Guid id)
    {
        const string sql = @"SELECT * FROM Expense WHERE Id = @Id";

        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Expense>(sql, new {Id = id});
    }

    public async Task<decimal> GetTotalExpenseAsync(DateTime startDate, DateTime endDate)
    {
        const string sql = @"
            SELECT COALESCE(SUM(Amount), 0)
            FROM Expense
            WHERE Date BETWEEN @StartDate AND @EndDate";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<decimal>(sql, new
        {
            StartDate = startDate,
            EndDate = endDate
        });
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
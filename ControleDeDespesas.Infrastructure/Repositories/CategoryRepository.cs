using ControleDeDespesas.Domain.Models;
using ControleDeDespesas.Domain.Repositories.Interfaces;
using ControleDeDespesas.Infrastructure.Data;
using Dapper;

namespace ControleDeDespesas.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly DapperContext _context;

    public CategoryRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Category category)
    {
        const string sql = @"INSERT INTO Category(Id, Name) VALUES (@Id, @Name)";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new
        {
            category.Id,
            category.Name
        });
    }

    public async Task DeleteAsync(Guid id)
    {
        const string sql = @"DELETE FROM Category WHERE Id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new{Id = id});
    }

    public async Task<(IEnumerable<Category> Items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize)
    {
        const string sql = @"SELECT * FROM Category ORDER BY Name OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY";
        var countSql = @"SELECT COUNT(Id) FROM Category";

        var paramtersPaged = new
        {
            Skip = (pageNumber - 1) * pageSize,
            Take = pageSize
        };

        using var connection = _context.CreateConnection();
        using var multiConsults = await connection.QueryMultipleAsync($"{countSql};{sql}", paramtersPaged);

        var totalItems = await multiConsults.ReadFirstAsync<int>();
        var category = await multiConsults.ReadAsync<Category>();
        return (category, totalItems);
        
    }

    public async Task<Category> GetByIdAsync(Guid id)
    {
        const string sql = @"SELECT * FROM Category WHERE Id = @Id";

        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Category>(sql, new{Id = id});
    }

    public async Task<Category> GetByNameAsync(string name)
    {
        const string sql = @"SELECT * FROM Category WHERE Name = @Name";
        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Category>(sql, new{ Name = name});
    }

    public async Task UpdateAsync(Category category)
    {
        const string sql = @"UPDATE Category SET Name = @Name WHERE Id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new{category.Id, category.Name});
    }
}
using ControleDeDespesas.Domain.Models;
using ControleDeDespesas.Domain.Repositories.Interfaces;
using ControleDeDespesas.Infrastructure.Data;
using Dapper;

namespace ControleDeDespesas.Infrastructure.Repositories;

public class PaymentMethodRepository : IPaymentMethodRepository
{
    private readonly DapperContext _context;

    public PaymentMethodRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task AddAsync(PaymentMethod paymentMethod)
    {
        const string sql = @"INSERT INTO PaymentMethod(Id, Name) VALUES (@Id, @Name)";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new
        {
            paymentMethod.Id,
            paymentMethod.Name
        });
    }

    public async Task DeleteAsync(Guid id)
    {
       const string sql = @"DELETE FROM PaymentMethod WHERE Id = @Id";

       using var connection = _context.CreateConnection();
       await connection.ExecuteAsync(sql, new{Id = id});
    }

    public async Task<IEnumerable<PaymentMethod>> GetAllAsync()
    {
        const string sql = @"SELECT * FROM PaymentMethod ORDER BY Name";

        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<PaymentMethod>(sql);
    }

    public async Task<PaymentMethod> GetByIdAsync(Guid id)
    {
        const string sql = @"SELECT * FROM PaymentMethod WHERE Id = @Id";

        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<PaymentMethod>(sql, new{Id = id});
    }

    public async Task<PaymentMethod> GetByNameAsync(string name)
    {
        const string sql = @"SELECT * FROM PaymentMethod WHERE Name = @Name";
        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<PaymentMethod>(sql, new{Name = name});
    }

    public async Task UpdateAsync(PaymentMethod paymentMethod)
    {
        const string sql = @"UPDATE PaymentMethod SET Name = @Name WHERE Id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new{paymentMethod.Id, paymentMethod.Name});
    }
}
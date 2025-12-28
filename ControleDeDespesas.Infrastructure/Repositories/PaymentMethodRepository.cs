using ControleDeDespesas.Domain.Models;
using ControleDeDespesas.Domain.Repositories.Interfaces;

namespace ControleDeDespesas.Infrastructure.Repositories;

public class PaymentMethodRepository : IPaymentMethodRepository
{
    public Task AddAsync(PaymentMethod paymentMethod)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PaymentMethod>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<PaymentMethod> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<PaymentMethod> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(PaymentMethod paymentMethod)
    {
        throw new NotImplementedException();
    }
}
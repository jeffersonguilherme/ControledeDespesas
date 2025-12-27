using ControleDeDespesas.Domain.Models;

namespace ControleDeDespesas.Domain.Repositories.Interfaces;

public interface IPaymentMethodRepository
{
    Task<PaymentMethod> GetByIdAsync(Guid id);
    Task<IEnumerable<PaymentMethod>> GetAllAsync();
    Task AddAsync(PaymentMethod paymentMethod);
    Task UpdateAsync(PaymentMethod paymentMethod);
    Task DeleteAsync(Guid id);
}
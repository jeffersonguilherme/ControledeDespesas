using ControleDeDespesas.Domain.Models;

namespace ControleDeDespesas.Domain.Repositories.Interfaces;

public interface IPaymentMethodRepository
{
    Task<PaymentMethod> GetByIdAsync(Guid id);
    Task<(IEnumerable<PaymentMethod> Items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize);
    Task AddAsync(PaymentMethod paymentMethod);
    Task UpdateAsync(PaymentMethod paymentMethod);
    Task DeleteAsync(Guid id);
    Task<PaymentMethod> GetByNameAsync(string name);
}
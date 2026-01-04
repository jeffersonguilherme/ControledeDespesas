using ControleDeDespesas.Domain.Models;

namespace ControleDeDespesas.Domain.Services;

public interface IPaymentMethodService
{
    Task AddAsync(PaymentMethod paymentMethod);
    Task<PaymentMethod> GetByIdAsync(Guid id);
    Task<(IEnumerable<PaymentMethod> Items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize);
    Task<PaymentMethod> GetByNameAsync(string name);
    Task UpdateAsync(PaymentMethod paymentMethod);
    Task DeleteAsync(Guid id);
}
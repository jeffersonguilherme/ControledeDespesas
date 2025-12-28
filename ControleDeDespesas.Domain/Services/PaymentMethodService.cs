using ControleDeDespesas.Domain.Models;
using ControleDeDespesas.Domain.Repositories.Interfaces;

namespace ControleDeDespesas.Domain.Services;

public class PaymentMethodService : IPaymentMethodService
{
    private readonly IPaymentMethodRepository _repository;

    public PaymentMethodService(IPaymentMethodRepository repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(PaymentMethod paymentMethod)
    {
        var existing = await _repository.GetByNameAsync(paymentMethod.Name);
        if(existing !=null)
            throw new InvalidOperationException("Já existe um método de pagamento com esse nome");

        await _repository.AddAsync(paymentMethod);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<PaymentMethod>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<PaymentMethod> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(PaymentMethod paymentMethod)
    {
        await _repository.UpdateAsync(paymentMethod);
    }
}
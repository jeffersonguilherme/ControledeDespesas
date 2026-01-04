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
        var existing = await _repository.GetByIdAsync(id);
        if(existing == null)
            throw new InvalidOperationException("Metodo de pagamento não encontrada");
        await _repository.DeleteAsync(id);
    }

    public async Task<(IEnumerable<PaymentMethod> Items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize)
    {
        return await _repository.GetAllAsync(pageNumber, pageSize);
    }

    public async Task<PaymentMethod> GetByIdAsync(Guid id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if(existing == null)
            throw new InvalidOperationException("Forma de pagamento não encontrada");
        return existing;
    }

    public async Task<PaymentMethod> GetByNameAsync(string name)
    {
        var existing = await _repository.GetByNameAsync(name);
        if(existing == null)
            throw new InvalidOperationException("Metodo de pagamento não encontrado");
        return existing;
    }

    public async Task UpdateAsync(PaymentMethod paymentMethod)
    {
        var existing = await _repository.GetByIdAsync(paymentMethod.Id);
        if(existing == null)
            throw new InvalidOperationException("Metodo de pagamento não encontrado");
        await _repository.UpdateAsync(paymentMethod);
    }
}
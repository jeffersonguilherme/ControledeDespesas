using ControleDeDespesas.Application.DTOs.Categories;
using ControleDeDespesas.Application.Interfaces;
using ControleDeDespesas.Application.Responses;

namespace ControleDeDespesas.Application.Services;

public class PaymentMethodAppService : IPaymentMethodAppService
{
    public Task<ResponseModel<PaymentMethodResponseDto>> AddPaymentMethodAsync(PaymentMethodCreateDto paymentMethodCreateDto)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<bool>> DeletePaymentMethodAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResponse<PaymentMethodResponseDto>> GetAllPaymentMethodIdAsync(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<PaymentMethodResponseDto>> GetByPaymentMethodIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<PaymentMethodResponseDto>> UpdatePaymentMethodAsync(Guid id, PaymentMethodUpdateDto paymentMethodUpdateDto)
    {
        throw new NotImplementedException();
    }
}
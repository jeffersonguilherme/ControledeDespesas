using ControleDeDespesas.Application.DTOs.Categories;
using ControleDeDespesas.Application.Responses;

namespace ControleDeDespesas.Application.Interfaces;

public interface IPaymentMethodAppService
{
    Task<ResponseModel<PaymentMethodResponseDto>> AddPaymentMethodAsync(PaymentMethodCreateDto paymentMethodCreateDto);
    Task<ResponseModel<PaymentMethodResponseDto>> GetByPaymentMethodIdAsync(Guid id);
    Task<PagedResponse<PaymentMethodResponseDto>> GetAllPaymentMethodIdAsync(int pageNumber, int pageSize);
    Task<ResponseModel<PaymentMethodResponseDto>> UpdatePaymentMethodAsync(Guid id, PaymentMethodUpdateDto paymentMethodUpdateDto);
    Task<ResponseModel<bool>> DeletePaymentMethodAsync(Guid id);
}
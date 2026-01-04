using AutoMapper;
using ControleDeDespesas.Application.DTOs.Categories;
using ControleDeDespesas.Application.Interfaces;
using ControleDeDespesas.Application.Responses;
using ControleDeDespesas.Domain.Models;
using ControleDeDespesas.Domain.Services;

namespace ControleDeDespesas.Application.Services;

public class PaymentMethodAppService : IPaymentMethodAppService
{
    private readonly IPaymentMethodService _service;
    private readonly IMapper _mapper;
    public PaymentMethodAppService(IPaymentMethodService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<ResponseModel<PaymentMethodResponseDto>> AddPaymentMethodAsync(PaymentMethodCreateDto paymentMethodCreateDto)
    {
        try
        {
            var payment = _mapper.Map<PaymentMethod>(paymentMethodCreateDto);
            await _service.AddAsync(payment);
            var paymentDto = _mapper.Map<PaymentMethodResponseDto>(payment);
            return new ResponseModel<PaymentMethodResponseDto>
            {
                Dados = paymentDto,
                Mensagem = "Metodo de pagamento criado com sucesso"
            };
        }catch(InvalidOperationException ex)
        {
            return new ResponseModel<PaymentMethodResponseDto>
            {
                Mensagem = ex.Message,
                Status = false
            };
        }
    }

    public async Task<ResponseModel<bool>> DeletePaymentMethodAsync(Guid id)
    {
        try
        {
            await _service.DeleteAsync(id);
            return new ResponseModel<bool>
            {
                Mensagem = "Metodo de pagamento excluído com sucesso"
            };
            
        }catch(InvalidOperationException ex)
        {
            return new ResponseModel<bool>
            {
                Mensagem = ex.Message,
                Status = false
            };
        }
    }

    public async Task<PagedResponse<PaymentMethodResponseDto>> GetAllPaymentMethodIdAsync(int pageNumber, int pageSize)
    {
        var (payment, totalItems) = await _service.GetAllAsync(pageNumber, pageSize);
        var paymentDto = _mapper.Map<IEnumerable<PaymentMethodResponseDto>>(payment);
        return new PagedResponse<PaymentMethodResponseDto>(
            paymentDto,
            pageNumber,
            pageSize,
            totalItems
        );
    }

    public async Task<ResponseModel<PaymentMethodResponseDto>> GetByPaymentMethodIdAsync(Guid id)
    {
        try
        {
            var payment = await _service.GetByIdAsync(id);
            var paymentDto = _mapper.Map<PaymentMethodResponseDto>(payment);
            return new ResponseModel<PaymentMethodResponseDto>
            {
              Dados = paymentDto,
              Mensagem = "Metodo obtido com sucesso"  
            };
        }catch(InvalidOperationException ex)
        {
            return new ResponseModel<PaymentMethodResponseDto>
            {
                Mensagem = ex.Message,
                Status = false
            };
        }
    }

    public Task<ResponseModel<PaymentMethodResponseDto>> UpdatePaymentMethodAsync(Guid id, PaymentMethodUpdateDto paymentMethodUpdateDto)
    {
        throw new NotImplementedException();
    }
}
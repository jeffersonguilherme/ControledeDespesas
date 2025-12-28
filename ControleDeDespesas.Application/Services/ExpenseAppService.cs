using AutoMapper;
using ControleDeDespesas.Application.DTOs.Expense;
using ControleDeDespesas.Application.Interfaces;
using ControleDeDespesas.Application.Responses;
using ControleDeDespesas.Domain.Models;
using ControleDeDespesas.Domain.Services;

namespace ControleDeDespesas.Application.Services;

public class ExpenseAppService : IExpenseAppService
{

    private readonly IExpenseService _service;
    private readonly IMapper _mapper;

    public ExpenseAppService(IExpenseService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<ResponseModel<ExpenseResponseDto>> AddExpenseAsync(ExpenseCreateDto expenseCreateDto)
    {
        try
        {
            var expense = _mapper.Map<Expense>(expenseCreateDto);
            await _service.AddAsync(expense);
            var expenseDto = _mapper.Map<ExpenseResponseDto>(expense);
            return new ResponseModel<ExpenseResponseDto>
            {
                Dados = expenseDto,
                Mensagem = "Despesa criada com sucesso"
            };
        }catch(ArgumentException ex)
        {
            return new ResponseModel<ExpenseResponseDto>
            {
                Mensagem = ex.Message,
                Status = false
            };
        }
    }

    public Task<ResponseModel<bool>> DeleteExpenseAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResponse<ExpenseResponseDto>> GetAllExpenseAsync(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResponse<ExpenseResponseDto>> GetByCategoryExpenseAsync(Guid id, int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<ExpenseResponseDto>> GetByIdExpenseAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<ExpenseUpdateDto>> UpdateExpenseAsync(Guid id, ExpenseUpdateDto expenseUpdateDto)
    {
        throw new NotImplementedException();
    }
}
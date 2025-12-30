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

    public async Task<ResponseModel<bool>> DeleteExpenseAsync(Guid id)
    {
        try
        {
            await _service.DeleteAsync(id);
            return new ResponseModel<bool>
            {
              Mensagem = "Despesa excluída com sucesso"  
            };
            
        }catch(ArgumentException ex)
        {
            return new ResponseModel<bool>
            {
                Mensagem = ex.Message,
                Status = false
            };
        }
    }

    public async Task<PagedResponse<ExpenseResponseDto>> GetAllAsync(int pageNumber, int pageSize)
{
    var (expenses, totalItems) = await _service.GetAllAsync(pageNumber, pageSize);

    var expensesDto = _mapper.Map<IEnumerable<ExpenseResponseDto>>(expenses);

    return new PagedResponse<ExpenseResponseDto>(
        expensesDto,
        pageNumber,
        pageSize,
        totalItems
    );
}

    public async Task<PagedResponse<ExpenseResponseDto>> GetByCategoryExpenseAsync(Guid id, int pageNumber, int pageSize)
    {
       var (expenses, totalItems) = await _service.GetByCategoryAsync(id, pageNumber, pageSize);

       var expensesDto = _mapper.Map<IEnumerable<ExpenseResponseDto>>(expenses);

       return new PagedResponse<ExpenseResponseDto>(
        expensesDto,
        pageNumber,
        pageSize,
        totalItems
       );
    }

    public async Task<ResponseModel<ExpenseResponseDto>> GetByIdExpenseAsync(Guid id)
    {
        var expense = await _service.GetByIdAsyn(id);
        var expenseDto = _mapper.Map<ExpenseResponseDto>(expense);
        return new ResponseModel<ExpenseResponseDto>{
          Dados = expenseDto,
          Mensagem = "Despensa obtida com sucesso."
        };
    }

    public async Task<PagedResponse<ExpenseResponseDto>> GetByPaymentMethodExpenseAsync(Guid paymentId, int pageNumber, int pageSize)
    {
        var (expenses, totalItems) = await _service.GetByPaymentMethodAsync(paymentId, pageNumber, pageSize);

        var expenseDto = _mapper.Map<IEnumerable<ExpenseResponseDto>>(expenses);

        return new PagedResponse<ExpenseResponseDto>(
            expenseDto,
            pageNumber,
            pageSize,
            totalItems
        );

    }

    public async Task<ResponseModel<decimal>> GetTotalExpenseAsync(DateTime startDate, DateTime endDate)
    {
        var coutTotal = await _service.GetTotalExpenseAsync(startDate, endDate);
        return new ResponseModel<decimal>
        {
          Dados = coutTotal,
          Mensagem = "Valor total da despensas"  
        };
    }

    public async Task<ResponseModel<ExpenseResponseDto>> UpdateExpenseAsync(Guid id, ExpenseUpdateDto expenseUpdateDto)
    {
        var expense = await _service.GetByIdAsyn(id);
        if(expense == null)
        {         
            return new ResponseModel<ExpenseResponseDto>
            {
                Status = false,
                Mensagem = "Despesa não econtrada"
            };
        }
        _mapper.Map(expenseUpdateDto, expense);
        await _service.UpdateAsync(expense);

        var expenseDto = _mapper.Map<ExpenseResponseDto>(expense);

        return new ResponseModel<ExpenseResponseDto>
        {
            Dados = expenseDto,
            Mensagem = "Despensa atualizada com sucesso!"
        };
    }
}
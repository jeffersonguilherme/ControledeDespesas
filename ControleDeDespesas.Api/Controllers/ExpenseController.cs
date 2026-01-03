using ControleDeDespesas.Application.DTOs.Expense;
using ControleDeDespesas.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeDespesas.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpenseController : ControllerBase
{
    private readonly IExpenseAppService _service;

    public ExpenseController(IExpenseAppService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddExpenseAsync(ExpenseCreateDto expenseCreateDto)
    {
        var response = await _service.AddExpenseAsync(expenseCreateDto);
        if(!response.Status)
            return BadRequest(response);
        
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdExpenseAsync(Guid id)
    {
        var expense = await _service.GetByIdExpenseAsync(id);
        return Ok(expense);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllExpensesAsync(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 3
    )
    {
        var expenses = await _service.GetAllAsync(pageNumber, pageSize);
        return Ok(expenses);
    }

    [HttpGet("{categoryId:guid}/expenses")]
    public async Task<IActionResult> GetByCategoryExpenseAsync(
        Guid categoryId,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int  pageSize = 3
    )
    {
        var expenses = await _service.GetByCategoryExpenseAsync(categoryId, pageNumber, pageSize);
        return Ok(expenses);
    }

    [HttpGet("{paymentMethodId:guid}/expense")]
    public async Task<IActionResult> GetByPaymentMethodExpenseAsync(
        Guid paymentMethodId,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 2
    )
    {
        var responses = await _service.GetByPaymentMethodExpenseAsync(paymentMethodId, pageNumber, pageSize);
        return Ok(responses);
    }

    [HttpGet("valorTotal")]
    public async Task<IActionResult> GetTotalExpensesAsync(
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate
    )
    {
        var total = await _service.GetTotalExpenseAsync(startDate, endDate);
        return Ok(total);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateExpenseAsync(Guid id, ExpenseUpdateDto expenseUpdateDto)
    {
        var expense = await _service.UpdateExpenseAsync(id, expenseUpdateDto);
        return Ok(expense);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteExpenseAsync(Guid id)
    {
        await _service.DeleteExpenseAsync(id);
        return Ok("Despensa Excluida com sucesso");
    }
}
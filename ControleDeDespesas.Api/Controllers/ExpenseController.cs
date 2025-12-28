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
}
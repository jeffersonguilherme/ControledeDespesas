using ControleDeDespesas.Application.DTOs.Categories;
using ControleDeDespesas.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeDespesas.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class PaymentMethodController : ControllerBase
{
    private readonly IPaymentMethodAppService _service;

    public PaymentMethodController(IPaymentMethodAppService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddPaymentMethodAsync(PaymentMethodCreateDto paymentMethodCreateDto)
    {
        var response = await _service.AddPaymentMethodAsync(paymentMethodCreateDto);
        if(!response.Status)
            return BadRequest(response);
        
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByPaymentMethodIdAsync(Guid id)
    {
        var response = await _service.GetByPaymentMethodIdAsync(id);
        if(!response.Status)
            return BadRequest(response);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPaymentMethodAsync(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10
    )
    {
        var response = await _service.GetAllPaymentMethodIdAsync(pageNumber, pageSize);
        return Ok(response);
    }

    [HttpPost("{id:guid}")]
    public async Task<IActionResult> UpdatePaymentMethodAsync(Guid id, PaymentMethodUpdateDto paymentMethodUpdateDto)
    {
        var response = await _service.UpdatePaymentMethodAsync(id, paymentMethodUpdateDto);
        return Ok(response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeletePaymentMethodAsync(Guid id)
    {
        var response = await _service.DeletePaymentMethodAsync(id);
        if(!response.Status)
            return BadRequest(response);
        return Ok("Metedo de pagamento exclído com sucesso");
    }
}
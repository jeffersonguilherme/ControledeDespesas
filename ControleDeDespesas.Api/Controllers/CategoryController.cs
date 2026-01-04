using ControleDeDespesas.Application.DTOs.Categories;
using ControleDeDespesas.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeDespesas.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly ICategoryAppService _service;

    public CategoriaController(ICategoryAppService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddCatetoryAsync(CategoryCreateDto categoryCreateDto)
    {
        var response = await _service.AddCategoryAsync(categoryCreateDto);
        if(!response.Status)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByCategoryIdAsync(Guid id)
    {
        var response = await _service.GetByCategoryIdAsync(id);
        if(!response.Status)
            return BadRequest(response);
        return  Ok(response);
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetByNameCategoryAsync(string name)
    {
        var response = await _service.GetByNameCategoryAsync(name);
        if(!response.Status)
            return BadRequest(response);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategoryAsync(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10
    )
    {
        var response = await _service.GetAllCategoryAsync(pageNumber, pageSize);
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateCategoryAsync(Guid id, CategoryUpdateDto categoryUpdateDto)
    {
        var response = await _service.UpdateCategoryAsync(id, categoryUpdateDto);
        return Ok(response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCategoryAsync(Guid id)
    {
        var response = await _service.DeleteCategoryAsync(id);
        if(!response.Status)
            return BadRequest(response);
        return Ok("Categoria excluída com sucesso");
    }
}
using ControleDeDespesas.Application.DTOs.Categories;
using ControleDeDespesas.Application.Responses;

namespace ControleDeDespesas.Application.Interfaces;

public interface ICategoryAppService
{
    Task<ResponseModel<CategoryResponseDto>> AddCategoryAsync(CategoryCreateDto categoryCreateDto);
    Task<ResponseModel<CategoryResponseDto>> GetByCategoryIdAsync(Guid id);
    Task<PagedResponse<CategoryResponseDto>> GetAllCategoryAsync(int pageNumber, int pageSize);
    Task<ResponseModel<CategoryResponseDto>> GetByNameCategoryAsync(string name);
    Task<ResponseModel<CategoryResponseDto>> UpdateCategoryAsync(Guid id, CategoryUpdateDto categoryUpdateDto);
    Task<ResponseModel<bool>>DeleteCategoryAsync(Guid id);
}
using AutoMapper;
using ControleDeDespesas.Application.DTOs.Categories;
using ControleDeDespesas.Application.Interfaces;
using ControleDeDespesas.Application.Responses;
using ControleDeDespesas.Domain.Models;
using ControleDeDespesas.Domain.Services;

namespace ControleDeDespesas.Application.Services;

public class CategoryAppService : ICategoryAppService
{
    private readonly ICategoryService _service;
    private readonly IMapper _mapper;

    public CategoryAppService(ICategoryService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<ResponseModel<CategoryResponseDto>> AddCategoryAsync(CategoryCreateDto categoryCreateDto)
    {
        try
        {
            var category = _mapper.Map<Category>(categoryCreateDto);
            await _service.AddAsync(category);
            var categoriaDto = _mapper.Map<CategoryResponseDto>(category);
            return new ResponseModel<CategoryResponseDto>
            {
                Dados = categoriaDto,
                Mensagem = "Categoria criada com sucesso"
            };
        }catch(InvalidOperationException ex)
        {
            return new ResponseModel<CategoryResponseDto>
            {
                Mensagem = ex.Message,
                Status = false
            };
        }
    }

    public async Task<ResponseModel<bool>> DeleteCategoryAsync(Guid id)
    {
        try
        {
            await _service.DeleteAsync(id);
            return new ResponseModel<bool>
            {
                Mensagem = "Categoria excluída com sucesso"
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

    public async Task<PagedResponse<CategoryResponseDto>> GetAllCategoryAsync(int pageNumber, int pageSize)
    {
            var (category, totalItems) = await _service.GetAllAsync(pageNumber, pageSize);
            var categoriaDto = _mapper.Map<IEnumerable<CategoryResponseDto>>(category);
            return new PagedResponse<CategoryResponseDto>(
                categoriaDto,
                pageNumber,
                pageSize,
                totalItems
            );
    }

    public async Task<ResponseModel<CategoryResponseDto>> GetByCategoryIdAsync(Guid id)
    {
        try
        {       
            var category = await _service.GetByIdAsync(id);
            var categoriaDto = _mapper.Map<CategoryResponseDto>(category);
            return new ResponseModel<CategoryResponseDto>
            {
                Dados = categoriaDto,
                Mensagem = "Categoria obtida com sucesso."
            };
        }catch(InvalidOperationException ex)
        {
            return new ResponseModel<CategoryResponseDto>
            {
                Mensagem = ex.Message,
                Status = false
            };
        }
    }

    public async Task<ResponseModel<CategoryResponseDto>> GetByNameCategoryAsync(string name)
    {
        try
        {
            var category = await _service.GetByNameAsync(name);
            var categoryDto = _mapper.Map<CategoryResponseDto>(category);
            return new ResponseModel<CategoryResponseDto>
            {
              Dados = categoryDto,
              Mensagem = "Categoria obtida com sucesso"  
            };
        }catch(InvalidOperationException ex)
        {
            return new ResponseModel<CategoryResponseDto>
            {
                Mensagem = ex.Message,
                Status = false
            };
        }
    }

    public async Task<ResponseModel<CategoryResponseDto>> UpdateCategoryAsync(Guid id, CategoryUpdateDto categoryUpdateDto)
    {
        try
        {
            var category = await _service.GetByIdAsync(id);
            _mapper.Map(categoryUpdateDto, category);
            await _service.UpdateAsync(category);

            var categoriaDto = _mapper.Map<CategoryResponseDto>(category);
            return new ResponseModel<CategoryResponseDto>
            {
                Dados = categoriaDto,
                Mensagem = "Categoria atualizada com sucesso"
            };
        }catch(InvalidOperationException ex)
        {
            return new ResponseModel<CategoryResponseDto>
            {
                Mensagem = ex.Message,
                Status = false
            };
        }

    }
}
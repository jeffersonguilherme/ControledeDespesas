using AutoMapper;
using ControleDeDespesas.Application.DTOs.Categories;
using ControleDeDespesas.Application.DTOs.Expense;
using ControleDeDespesas.Domain.Models;

namespace ControleDeDespesas.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CategoryCreateDto, Category>();
        CreateMap<CategoryUpdateDto, Category>();
        CreateMap<Category, CategoryResponseDto>();

        CreateMap<ExpenseCreateDto, Expense>();
        CreateMap<ExpenseUpdateDto, Expense>();
        CreateMap<Expense, ExpenseResponseDto>();

        CreateMap<PaymentMethodCreateDto, PaymentMethod>();
        CreateMap<PaymentMethodUpdateDto, PaymentMethod>();
        CreateMap<PaymentMethod, PaymentMethodResponseDto>();
    }
}
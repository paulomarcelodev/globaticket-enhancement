using AutoMapper;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries;

public class GetCategoryDetailProfile : Profile
{
    public GetCategoryDetailProfile()
    {
        CreateMap<Category, GetCategoryDetailVm>();
    }
}
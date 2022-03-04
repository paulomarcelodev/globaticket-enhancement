using AutoMapper;
using GloboTicket.TicketManagement.Application.Abstractions.Messaging;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Responses;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoryDetailByName;

public class GetCategoryDetailByNameQueryHandler : IQueryHandler<GetCategoryDetailByNameQuery, GetCategoryDetailQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Category> _categoryRepository;

    public GetCategoryDetailByNameQueryHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<GetCategoryDetailQueryResponse> Handle(GetCategoryDetailByNameQuery request,
        CancellationToken cancellationToken)
    {
        var response = new GetCategoryDetailQueryResponse();
        var viewModel = _mapper.Map<GetCategoryDetailVm>(
            (await _categoryRepository.ListAllAsync()).FirstOrDefault(c => c.Name == request.Name));
        if (viewModel is null)
        {
            response.Success = false;
            response.ValidationErrors.Add($"Category with name {request.Name} not found.");
        }
        else
        {
            response.Data = viewModel;
        }
        return response;
    }
}
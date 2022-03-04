using AutoMapper;
using GloboTicket.TicketManagement.Application.Abstractions.Messaging;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoryDetailById;

public class GetCategoryDetailByIdQueryHandler : IQueryHandler<GetCategoryDetailByIdQuery, GetCategoryDetailQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Category> _categoryRepository;

    public GetCategoryDetailByIdQueryHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<GetCategoryDetailQueryResponse> Handle(GetCategoryDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var response = new GetCategoryDetailQueryResponse();
        var viewModel = _mapper.Map<GetCategoryDetailVm>(
            await _categoryRepository.GetByIdAsync(request.Id));
        if (viewModel is null)
        {
            response.Success = false;
            response.ValidationErrors.Add($"Category with ID {request.Id} not found.");
        }
        else
        {
            response.Data = viewModel;
        }
        return response;
    }
}
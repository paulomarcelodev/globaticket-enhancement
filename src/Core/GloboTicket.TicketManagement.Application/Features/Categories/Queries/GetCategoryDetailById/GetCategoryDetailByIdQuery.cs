using GloboTicket.TicketManagement.Application.Abstractions.Messaging;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoryDetailById;

public class GetCategoryDetailByIdQuery : IQuery<GetCategoryDetailQueryResponse>
{
    public Guid Id { get; set; }
}
using GloboTicket.TicketManagement.Application.Abstractions.Messaging;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoryDetailByName;

public class GetCategoryDetailByNameQuery : IQuery<GetCategoryDetailQueryResponse>
{
    public string Name { get; set; }
}
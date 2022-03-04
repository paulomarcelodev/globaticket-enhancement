using GloboTicket.TicketManagement.Application.Responses;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries;

public class GetCategoryDetailQueryResponse : BaseResponse
{
    public GetCategoryDetailVm Data { get; set; }
}
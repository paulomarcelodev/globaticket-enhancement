using GloboTicket.TicketManagement.Application.Responses;

namespace GloboTicket.TicketManagement.Application.Abstractions.Messaging;

public interface IIdempotentCommand<out TResponse> : ICommand<TResponse> where TResponse : BaseResponse
{
    Guid RequestId { get; set; }
}
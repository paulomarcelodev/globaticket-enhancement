using MediatR;

namespace GloboTicket.TicketManagement.Application.Abstractions.Messaging;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}
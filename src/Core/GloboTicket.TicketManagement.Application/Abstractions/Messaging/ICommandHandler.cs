using GloboTicket.TicketManagement.Application.Responses;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Abstractions.Messaging;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse> where TResponse : BaseResponse
{
}
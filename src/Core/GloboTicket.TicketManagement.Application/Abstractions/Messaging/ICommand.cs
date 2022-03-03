using GloboTicket.TicketManagement.Application.Responses;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Abstractions.Messaging;

public interface ICommand<out TResponse> : IRequest<TResponse> where TResponse : BaseResponse
{
}
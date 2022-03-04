using GloboTicket.TicketManagement.Domain.Common;

namespace GloboTicket.TicketManagement.Application.Contracts.Persistence;

public interface IAsyncRepository<T> where T : Entity
{
    Task<T?> GetByIdAsync(Guid id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
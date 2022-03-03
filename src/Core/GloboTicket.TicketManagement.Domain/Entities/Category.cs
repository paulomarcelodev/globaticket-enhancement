using GloboTicket.TicketManagement.Domain.Common;

namespace GloboTicket.TicketManagement.Domain.Entities;

public class Category : AuditableEntity
{
    public string Name { get; set; }
    public ICollection<Event> Events { get; set; }
}
namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries;

public class GetCategoryDetailVm
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}
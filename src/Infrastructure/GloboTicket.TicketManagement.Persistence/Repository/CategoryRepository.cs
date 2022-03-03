using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Persistence.Repository;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(GloboTicketDbContext dbContext) : base(dbContext)
    {
    }
    
    public Task<bool> IsCategoryNameUnique(string categoryName)
    {
        var matches = _dbContext.Categories.Any(e => e.Name.Equals(categoryName));
        return Task.FromResult(matches);
    }
}
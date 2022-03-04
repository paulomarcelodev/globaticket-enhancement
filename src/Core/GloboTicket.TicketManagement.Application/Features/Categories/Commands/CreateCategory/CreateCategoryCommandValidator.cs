using FluentValidation;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    
    public CreateCategoryCommandValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
        
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(e => e)
            .MustAsync(CategoryNameUnique)
            .WithMessage("A category with the same name and date already exists.");
    }

    private async Task<bool> CategoryNameUnique(CreateCategoryCommand c, CancellationToken token)
    {
        return !await _categoryRepository.IsCategoryNameUnique(c.Name!);
    }
}
using GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.TicketManagement.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ISender _sender;
    
    public CategoriesController(ISender sender) => _sender = sender;
    
    /// <summary>
    /// Create a new category if name is avaliable
    /// </summary>
    /// <param name="command">The command to create category.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>New category created</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(command, cancellationToken);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result); 
    }
}
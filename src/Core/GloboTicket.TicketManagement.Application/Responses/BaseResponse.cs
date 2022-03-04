namespace GloboTicket.TicketManagement.Application.Responses;

public abstract class BaseResponse
{
    public BaseResponse()
    {
        Success = true;
        ValidationErrors = new List<string>();
    }

    public BaseResponse(string message)
    {
        Success = true;
        Message = message;
        ValidationErrors = new List<string>();
    }

    public BaseResponse(string message,bool success)
    {
        Success = success;
        Message = message;
        ValidationErrors = new List<string>();
    }
    
    public bool Success { get; set; }
    public string? Message { get; set; }
    public List<string> ValidationErrors { get; }
    
}
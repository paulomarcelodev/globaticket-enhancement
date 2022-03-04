using GloboTicket.TicketManagement.Application;
using GloboTicket.TicketManagement.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(
    builder.Configuration, 
    "GloboTicketManagementConnectionString", 
    "GloboTicket.TicketManagement.Api");
builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("Open");
app.UseAuthorization();
app.MapControllers();
app.Run();
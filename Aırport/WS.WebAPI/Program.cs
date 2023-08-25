using WS.Business.Extensions;
using WS.WebAPI.Extensions;
using WS.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAPIServices();

builder.Services.AddBusinessServices();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

app.UseCustomException();

app.Run();

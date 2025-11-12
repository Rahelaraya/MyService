using MyService.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<GreetingService>(); // registrera din service

var app = builder.Build();

// Middleware & Swagger (dev)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Din endpoint
app.MapGet("/hello/{name}", (string name, GreetingService service) =>
{
    var message = service.SayHello(name);
    return Results.Ok(new { message });
});

app.Run();

// (valfri template-klass – kan tas bort om den inte används)
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

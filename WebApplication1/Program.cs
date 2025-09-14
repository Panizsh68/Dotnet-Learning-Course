
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Routing
// "/shirts"
app.MapGet("/shirts", () =>
{
    return "Reading all the shirts";
});

app.MapGet("/shirts/{id}", (int id) =>
{
    return $"Reading shirt with id {id}";
});

app.MapPost("/shirts", () =>
{
    return "Creating a new shirt";
});

app.MapPut("/shirts/{id}", (int id) =>
{
    return $"Updating shirt with id {id}";
});

app.MapDelete("/shirts/{id}", (int id) =>
{
    return $"Deleting shirt with id {id}";
});
app.Run();

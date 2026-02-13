var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger in all environments (useful for testing on Render)
app.UseSwagger();
app.UseSwaggerUI();

// Remove HTTPS redirection for Render (Render handles SSL at the edge)
// app.UseHttpsRedirection();

app.UseAuthorization();

// Root endpoint for health checks
app.MapGet("/", () => "API is running! Go to /swagger for API docs");

// Hello endpoint
app.MapGet("/hello", () => "Hello from Render running .NET 9!");

app.MapControllers();

app.Run();

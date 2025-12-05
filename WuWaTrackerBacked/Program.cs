using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// 1. Add services to the container.
builder.Services.AddControllers();

// Standard Swagger for .NET 8
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Add CORS (Critical for React connection)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// 3. Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Important: Comment out HttpsRedirection if running in simple Docker containers to avoid port issues
// app.UseHttpsRedirection(); 

app.UseAuthorization();

// 4. Enable CORS
app.UseCors("AllowReactApp");

app.MapControllers();

// 5. Run the app (Listening on all interfaces for Docker)
app.Run();
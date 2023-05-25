using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Minimal_API_EF_Core_Oracle.Data;
using Minimal_API_EF_Core_Oracle.Endpoints;
using Minimal_API_EF_Core_Oracle.Services;
using Minimal_API_EF_Core_Oracle.Validation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblyContaining(typeof(TodoCreateValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(TodoUpdateValidator));

builder.Services.AddScoped<ITodoService, TodoService>();

builder.Services.AddDbContext<TodoItemContext>(options =>
{
    var configuration = builder.Configuration.GetConnectionString("TodoItemContext");
    options.UseOracle(configuration, options => options.UseOracleSQLCompatibility("11"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Todo API",
        Description = "minimal API for creating todo items",
        Version = "v1"
    });
});

var app = builder.Build();

app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.MapTodoEndpoints();

app.Run();

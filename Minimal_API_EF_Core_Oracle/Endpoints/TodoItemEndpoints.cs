using FluentValidation;
using Minimal_API_EF_Core_Oracle.Dtos;
using Minimal_API_EF_Core_Oracle.Exceptions;
using Minimal_API_EF_Core_Oracle.Services;

namespace Minimal_API_EF_Core_Oracle.Endpoints
{
    public static class TodoEndpoints
    {
        private static readonly ILogger _logger =
            LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            }).CreateLogger(typeof(TodoEndpoints));


        public static void MapTodoEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/todoitems", GetAllTodoItems);
            app.MapGet("/todoitems/{id}", GetTodoItemById).WithName("GetTodoItemById");
            app.MapGet("/todoitems/done", GetDoneTodoItems);
            app.MapPost("/todoitems", CreateTodoItem);
            app.MapPut("/todoitems/update", UpdateTodoItem);
            app.MapDelete("/todoitems/{id}", DeleteTodoItem);
        }

        private static async Task<IResult> GetAllTodoItems(ITodoService todoService)
        {
            try
            {
                var todoItems = await todoService.GetAllTodoItems();

                return !todoItems.Any()
                    ? Results.NotFound("No todoitems in DB")
                    : Results.Ok(todoItems);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exception: {ex.Message}");
                return Results.BadRequest("Internal server problem");
            }
        }

        private static async Task<IResult> GetTodoItemById(ITodoService todoService, decimal id)
        {
            try
            {
                var todoItem = await todoService.GetTodoItemById(id);
                return Results.Ok(todoItem);
            }

            catch (TodoNotFoundException ex)
            {
                _logger.LogInformation($"Exception: {ex.Message}");
                return Results.NotFound("No todoitem in DB with given id");
            }

            catch (Exception ex)
            {
                _logger.LogInformation($"Exception: {ex.Message}");
                return Results.BadRequest("Internal server problem");
            }
        }

        private static async Task<IResult> GetDoneTodoItems(ITodoService todoService)
        {
            try
            {
                var todoitems = await todoService.GetDoneTodoItems();

                return todoitems.Count() == 0
                    ? Results.NotFound("No completed todoitems found in DB")
                    : Results.Ok(todoitems);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exception: {ex.Message}");
                return Results.BadRequest("Internal server problem");
            }
        }

        private static async Task<IResult> CreateTodoItem(TodoItemCreateDto newTodoItem, ITodoService todoService, IValidator<TodoItemCreateDto> validator)
        {
            var validation = await validator.ValidateAsync(newTodoItem);
            if (!validation.IsValid)
            {
                return Results.ValidationProblem(validation.ToDictionary());
            }


            try
            {
                var newItemId = await todoService.CreateTodoItem(newTodoItem);
                return Results.CreatedAtRoute("GetTodoItemById", new { id = newItemId }, new { id = newItemId });
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exception: {ex.Message}");
                return Results.BadRequest("Internal server problem");
            }
        }

        private static async Task<IResult> UpdateTodoItem(TodoItemUpdateDto todoItemToUpdate, ITodoService todoService, IValidator<TodoItemUpdateDto> validator)
        {
            var validation = await validator.ValidateAsync(todoItemToUpdate);
            if (!validation.IsValid)
            {
                return Results.ValidationProblem(validation.ToDictionary());
            }

            try
            {
                await todoService.UpdateTodoItem(todoItemToUpdate);
                return Results.Ok();
            }
            catch (TodoNotFoundException ex)
            {
                _logger.LogInformation($"Exception: {ex.Message}");
                return Results.NotFound("No todoitem in DB with given id");
            }

            catch (Exception ex)
            {
                _logger.LogInformation($"Exception: {ex.Message}");
                return Results.BadRequest("Internal server problem");
            }
        }

        private static async Task<IResult> DeleteTodoItem(decimal id, ITodoService todoService)
        {
            try
            {
                await todoService.DeleteTodoItem(id);

                return Results.NoContent();
            }

            catch (TodoNotFoundException ex)
            {
                _logger.LogInformation($"Exception: {ex.Message}");
                return Results.NotFound("No todoitem in DB with given id");
            }

            catch (Exception ex)
            {
                _logger.LogInformation($"Exception: {ex.Message}");
                return Results.BadRequest("Internal server problem");
            }
        }
    }
}

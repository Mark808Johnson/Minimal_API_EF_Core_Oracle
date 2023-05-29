using Microsoft.EntityFrameworkCore;
using Minimal_API_EF_Core_Oracle.Data;
using Minimal_API_EF_Core_Oracle.Dtos;
using Minimal_API_EF_Core_Oracle.Exceptions;
using Minimal_API_EF_Core_Oracle.Models;


namespace Minimal_API_EF_Core_Oracle.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItemReadDto>> GetAllTodoItems();
        Task<TodoItemReadDto> GetTodoItemById(int id);
        Task<IEnumerable<TodoItemReadDto>> GetDoneTodoItems();
        Task<decimal> CreateTodoItem(TodoItemCreateDto newTodoItem);
        Task UpdateTodoItem(TodoItemUpdateDto todoItemToUpdate);
        Task DeleteTodoItem(int id);
    }

    public class TodoService : ITodoService
    {
        private readonly TodoItemContext _db;

        public TodoService(TodoItemContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TodoItemReadDto>> GetAllTodoItems()
        {
            var todoitems = await _db.TodoItems.ToListAsync();

            var dtos = todoitems.Select(item => new TodoItemReadDto
            {
                Id = item.Id,
                Description = item.Description,
                CreationTs = item.CreationTs,
                Done = item.Done,
            }).ToList();

            return dtos;
        }

        public async Task<TodoItemReadDto> GetTodoItemById(int id)
        {
            var todoItem = await _db.TodoItems.FirstOrDefaultAsync(x => x.Id == id);

            if (todoItem == null)
            {
                throw new TodoNotFoundException("No todo item with given id found in database");
            }

            var dto = new TodoItemReadDto
            {
                Id = todoItem.Id,
                Description = todoItem.Description,
                CreationTs = todoItem.CreationTs,
                Done = todoItem.Done,
            };

            return dto;
        }

        public async Task<IEnumerable<TodoItemReadDto>> GetDoneTodoItems()
        {
            var todoItems = await _db.TodoItems.Where(x => x.Done).ToListAsync();

            var dtos = todoItems.Select(item => new TodoItemReadDto
            {
                Id = item.Id,
                Description = item.Description,
                CreationTs = item.CreationTs,
                Done = item.Done,
            }).ToList();
            return dtos;
        }

        public async Task<decimal> CreateTodoItem(TodoItemCreateDto newTodoItem)
        {
            var todoItem = new TodoItem
            {
                Description = newTodoItem.Description,
                CreationTs = DateTimeOffset.UtcNow,
                Done = false,
            };


            _db.TodoItems.Add(todoItem);
            await _db.SaveChangesAsync();

            return todoItem.Id;
        }

        public async Task UpdateTodoItem(TodoItemUpdateDto todoItemToUpdate)
        {
            var existingTodoitem = await _db.TodoItems.FirstOrDefaultAsync(x => x.Id == todoItemToUpdate.Id);

            if (existingTodoitem == null)
            {
                throw new TodoNotFoundException("No todo item with given id found in database");
            }

            if (todoItemToUpdate.Description != null)
            {
                existingTodoitem.Description = todoItemToUpdate.Description;
            }

            if (todoItemToUpdate.Done != null)
            {
                existingTodoitem.Done = (bool)todoItemToUpdate.Done;
            }

            await _db.SaveChangesAsync();
        }

        public async Task DeleteTodoItem(int id)
        {

            var todoItem = await _db.TodoItems.FirstOrDefaultAsync(x => x.Id == id);

            if (todoItem == null)
            {
                throw new TodoNotFoundException("No todo item with given id found in database");
            }

            _db.TodoItems.Remove(todoItem);
            await _db.SaveChangesAsync();
        }
    }
}
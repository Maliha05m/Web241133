using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web1.Model;

namespace Web1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private static readonly List<TodoItem> _todoItems = new()
        {
            new TodoItem
            {
                Id = 1,
                Name = "Learn .NET Core",
                IsComplete = true,
                Secret = "Shh!"
            },

            new TodoItem
            {
                Id = 2,
                Name = "Build Web API",
                IsComplete = true,
                Secret = "Secret-2"
            },

             new TodoItem
            {
                Id = 3,
                Name = "MY FIRST API - YUSRA",
                IsComplete = true,
                Secret = "Secret-DON'T TELL"
            },


             new TodoItem
            {
                Id = 4,
                Name = "MY FRIEND'S API - MALIHA",
                IsComplete = true,
                Secret = "Secret-DON'T TELL"
            },

               new TodoItem
            {
                Id = 5,
                Name = "MY FRIEND'S API - AMBREEN",
                IsComplete = true,
                Secret = "Secret-DON'T TELL"
            },


        };
        private static long _nextId = 6;

        [HttpGet]
        public ActionResult<List<TodoItem>> GetTodoItems()
        {
            return _todoItems;
        }

        [HttpGet("{id}")]

        public ActionResult<TodoItem> GetTodoItem(long id)
        {
            var todoItem = _todoItems.FirstOrDefault(t => t.Id == id);
            if (todoItem == null)
            {
                return NotFound();

            }
            return todoItem;
        }

        [HttpPost]
        public void PostTodoItem(TodoItem todoItem)
        {
            todoItem.Id = _nextId++;
            _todoItems.Add(todoItem);
        }

        [HttpDelete("{id}")]
        public void DeleteTodoItem(long id)
        {
            var todoItem = _todoItems.FirstOrDefault(t => t.Id == id);
            _todoItems.Remove(todoItem);
        }

        [HttpPut("{id}")]
        public void PutTodoItem(long id, TodoItem todoItem)
        {
            var existingItem = _todoItems.FirstOrDefault(t => t.Id == id);
            existingItem.Name = todoItem.Name;
            existingItem.IsComplete = todoItem.IsComplete;

        }
    }
}

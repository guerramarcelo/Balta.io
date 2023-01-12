using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public List<TodoModel> Get([FromServices] AppDbContext context)
        {
            return context.Todos.ToList();
        }

        [HttpGet("/{id:int}")]
        public TodoModel GetById(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            return context.Todos.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost("/")]
        public TodoModel Post(
            [FromBody] TodoModel todo,
            [FromServices] AppDbContext context
            )
        {
            context.Todos.Add(todo);
            context.SaveChanges();
            return todo;

        }

        [HttpPut("/{id:int}")]
        public TodoModel Put(
          [FromRoute] int id,
          [FromBody] TodoModel todo,
          [FromServices] AppDbContext context
          )
        {
            var todos = context.Todos.FirstOrDefault(x => x.Id == id);
            if (todos == null)
                return todo;
            
            todos.Title = todo.Title;
            todos.Done= todo.Done;

            context.Todos.Update(todos);
            context.SaveChanges();
            return todos;
        }

        [HttpDelete("/{id:int}")]
        public TodoModel Delete(
         [FromRoute] int id,         
         [FromServices] AppDbContext context
         )
        {
            var todos = context.Todos.FirstOrDefault(x => x.Id == id);            
            context.Todos.Remove(todos);
            context.SaveChanges();
            return todos;
        }

    }
}

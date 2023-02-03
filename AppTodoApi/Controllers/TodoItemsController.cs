using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppTodoApi.Data;
using AppTodoApi.Models;

namespace AppTodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly AppTodoApiContext _context;

        public TodoItemsController(AppTodoApiContext context)
        {
            _context = context;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItems>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItems>> GetTodoItems(int id)
        {
            var todoItems = await _context.TodoItems.FindAsync(id);

            if (todoItems == null)
            {
                return NotFound();
            }

            return todoItems;
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItems(int id, TodoItems todoItems)
        {
            if (id != todoItems.TodoItemsId)
            {
                return BadRequest();
            }

            _context.Entry(todoItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoItems>> PostTodoItems(TodoItems todoItems)
        {
            _context.TodoItems.Add(todoItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoItems", new { id = todoItems.TodoItemsId }, todoItems);
        }





        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItems(int id)
        {
            var todoItems = await _context.TodoItems.FindAsync(id);
            if (todoItems == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoItemsExists(int id)
        {
            return _context.TodoItems.Any(e => e.TodoItemsId == id);
        }
    }
}

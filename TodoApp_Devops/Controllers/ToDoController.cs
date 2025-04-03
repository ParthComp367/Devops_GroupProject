using Microsoft.AspNetCore.Mvc;
using ToDoApp_Devops.Data;
using ToDoApp_Devops.Models;

namespace ToDoApp_Devops.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoContext _context;

        public ToDoController(ToDoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.ToDoItems.ToList());
        }

        [HttpPost]
        public IActionResult Post([FromBody] ToDoItem item)
        {
            _context.ToDoItems.Add(item);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ToDoItem item)
        {
            var existing = _context.ToDoItems.Find(id);
            if (existing == null) return NotFound();

            existing.Title = item.Title;
            existing.IsCompleted = item.IsCompleted;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.ToDoItems.Find(id);
            if (item == null) return NotFound();

            _context.ToDoItems.Remove(item);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

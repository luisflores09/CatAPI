using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatAPI.Data;
using CatAPI.Models;

namespace CatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        private readonly CatDbContext _context;
        public CatsController(CatDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cat>>> GetCats()
        {
            return await _context.Cats.ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Cat>> GetCat(int id)
        {
            var cat = await _context.Cats.FindAsync(id);
            if(cat == null) return NotFound();
            return cat;
        }

        [HttpPost]
        public async Task<ActionResult<Cat>> CreateCat(Cat cat)
        {
            _context.Cats.Add(cat);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCat), new { id = cat.Id }, cat);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstRestApi.Data.Models;
using TodoApi.Models;

namespace MyFirstRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestUsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TestUsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TestUsersTwo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestUser>>> GetTestUsers()
        {
            return await _context.TestUsers.ToListAsync();
        }

        // GET: api/TestUsersTwo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestUser>> GetTestUser(int id)
        {
            var testUser = await _context.TestUsers.FindAsync(id);

            if (testUser == null)
            {
                return NotFound();
            }

            return testUser;
        }

        // PUT: api/TestUsersTwo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestUser(int id, TestUser testUser)
        {
            if (id != testUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(testUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestUserExists(id))
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

        // POST: api/TestUsersTwo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TestUser>> PostTestUser(TestUser testUser)
        {
            _context.TestUsers.Add(testUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestUser", new { id = testUser.Id }, testUser);
        }

        // DELETE: api/TestUsersTwo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestUser(int id)
        {
            var testUser = await _context.TestUsers.FindAsync(id);
            if (testUser == null)
            {
                return NotFound();
            }

            _context.TestUsers.Remove(testUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestUserExists(int id)
        {
            return _context.TestUsers.Any(e => e.Id == id);
        }
    }
}

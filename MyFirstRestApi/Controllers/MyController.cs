using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstRestApi.Data.Models;
using TodoApi.Models;

namespace MyFirstRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MyController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/My/GetMyData
        [HttpGet("GetMyData")]
        public async Task<ActionResult<string>> GetMyData()
        {
            var rowData = _context.TestUsers.Where(tu => tu.Id == 1).FirstOrDefault();
            //var cartRowData = _context.Carts.FirstOrDefault();

            return rowData.Id + rowData.Name + rowData.Email;
        }
    }
}

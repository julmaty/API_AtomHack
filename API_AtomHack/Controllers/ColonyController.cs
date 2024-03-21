using API_AtomHack.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_AtomHack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColonyController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ColonyController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colony>>> Get()
        {
            return await _context.Colonies.ToListAsync();
        }
    }
}

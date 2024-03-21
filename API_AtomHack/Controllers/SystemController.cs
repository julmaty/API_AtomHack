using API_AtomHack.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_AtomHack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public SystemController(ApplicationContext context)
        {
            _context = context;
        }
        //список систем
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model.System>>> Get()
        {
            return await _context.Systems.ToListAsync();
        }
    }
}

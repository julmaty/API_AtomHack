using API_AtomHack.Model;
using API_AtomHack.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_AtomHack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public AccessController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Access>>> Get()
        {
            return await _context.Access.ToListAsync();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Access>>> Get(int ColonyId, int SystemId)
        {
            List<Access> docs = _context.Access.Where(p => p.ColonyId == ColonyId && p.SystemId == SystemId).ToList();
            return docs;
        }
        [HttpPost]
        public async Task<ActionResult> Post(DocumentationView doc)
        {
            var user = await _context.Users.FindAsync(doc.UserId);
            var userHistory = new userHistory { Case = 3, ColonyId = doc.ColonyId, SystemId = doc.SystemId, UserId = user.Id, DateTime = DateTime.Now };
            _context.userHistories.Add(userHistory);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

using API_AtomHack.Model;
using API_AtomHack.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace API_AtomHack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentationController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public DocumentationController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Documentation>>> Get()
        {
            return await _context.Documentations.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult> Post(DocumentationView doc)
        {
            var user = await _context.Users.FindAsync(doc.UserId);
            var userHistory = new userHistory { Case = 2, ColonyId = doc.ColonyId, SystemId=doc.SystemId, UserId = user.Id, DateTime = DateTime.Now };
            _context.userHistories.Add(userHistory);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_AtomHack;

namespace API_AtomHack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportCategoriesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ReportCategoriesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ReportCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportCategory>>> GetReportDescription()
        {
            return await _context.ReportCategories.ToListAsync();
        }

        // GET: api/ReportCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReportCategory>> GetReportCategory(int id)
        {
            var reportCategory = await _context.ReportCategories.FindAsync(id);

            if (reportCategory == null)
            {
                return NotFound();
            }

            return reportCategory;
        }

        // PUT: api/ReportCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReportCategory(int id, ReportCategory reportCategory)
        {
            if (id != reportCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(reportCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportCategoryExists(id))
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

        // POST: api/ReportCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReportCategory>> PostReportCategory(ReportCategory reportCategory)
        {
            _context.ReportCategories.Add(reportCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReportCategory", new { id = reportCategory.Id }, reportCategory);
        }

        // DELETE: api/ReportCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReportCategory(int id)
        {
            var reportCategory = await _context.ReportCategories.FindAsync(id);
            if (reportCategory == null)
            {
                return NotFound();
            }

            _context.ReportCategories.Remove(reportCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReportCategoryExists(int id)
        {
            return _context.ReportCategories.Any(e => e.Id == id);
        }
    }
}

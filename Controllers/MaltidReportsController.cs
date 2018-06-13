using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaltidRapporter.Models;

namespace MaltidRapporter.Controllers
{
    [Produces("application/json")]
    [Route("api/MaltidReports")]
    public class MaltidReportsController : Controller
    {
        private readonly MaltidDbContext _context;

        public MaltidReportsController(MaltidDbContext context)
        {
            _context = context;
        }

        // GET: api/MaltidReports
        [HttpGet]
        public IEnumerable<MaltidReport> GetMaltidReport()
        {
            return _context.MaltidReport;
        }

        // GET: api/MaltidReports/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaltidReport([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var maltidReport = await _context.MaltidReport.SingleOrDefaultAsync(m => m.Rapport_ID == id);

            if (maltidReport == null)
            {
                return NotFound();
            }

            return Ok(maltidReport);
        }

        [HttpGet("{verksamhet}/{datum}")]
        public async Task<IActionResult> GetMaltidReport([FromRoute] string verksamhet, [FromRoute] DateTime datum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var maltidRapporter = await _context.MaltidReport.Where(m => m.Verksamhet_ID == verksamhet && ((DateTime)m.Rapport_Datum).Date == datum.Date).ToListAsync();

            if (maltidRapporter == null)
            {
                return NotFound();
            }

            return Ok(maltidRapporter);
        }


        // PUT: api/MaltidReports/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaltidReport([FromRoute] int id, [FromBody] MaltidReport maltidReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != maltidReport.Rapport_ID)
            {
                return BadRequest();
            }

            _context.Entry(maltidReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaltidReportExists(id))
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

        // POST: api/MaltidReports
        [HttpPost]
        public async Task<IActionResult> PostMaltidReport([FromBody] MaltidReport maltidReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            maltidReport.Rapport_ID = null;

            _context.MaltidReport.Add(maltidReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaltidReport", new { id = maltidReport.Rapport_ID }, maltidReport);
        }

        // DELETE: api/MaltidReports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaltidReport([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var maltidReport = await _context.MaltidReport.SingleOrDefaultAsync(m => m.Rapport_ID == id);
            if (maltidReport == null)
            {
                return NotFound();
            }

            _context.MaltidReport.Remove(maltidReport);
            await _context.SaveChangesAsync();

            return Ok(maltidReport);
        }

        private bool MaltidReportExists(int id)
        {
            return _context.MaltidReport.Any(e => e.Rapport_ID == id);
        }
    }
}
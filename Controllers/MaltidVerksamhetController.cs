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
    [Route("api/MaltidVerksamhet")]
    public class MaltidVerksamhetController : Controller
    {
        private readonly MaltidDbContext _context;

        public MaltidVerksamhetController(MaltidDbContext context)
        {
            _context = context;
        }

        // GET: api/MaltidVerksamhet
        [HttpGet]
        public IEnumerable<MaltidVerksamhet> GetMaltidVerksamhet()
        {
            return _context.MaltidVerksamhet;
        }

        // GET: api/MaltidVerksamhet/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaltidVerksamhet([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var maltidVerksamhet = await _context.MaltidVerksamhet.SingleOrDefaultAsync(m => m.Verksamhet_ID == id);

            if (maltidVerksamhet == null)
            {
                return NotFound();
            }

            return Ok(maltidVerksamhet);
        }

        // PUT: api/MaltidVerksamhet/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaltidVerksamhet([FromRoute] int id, [FromBody] MaltidVerksamhet maltidVerksamhet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != maltidVerksamhet.ID)
            {
                return BadRequest();
            }

            _context.Entry(maltidVerksamhet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaltidVerksamhetExists(id))
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

        // POST: api/MaltidVerksamhet
        [HttpPost]
        public async Task<IActionResult> PostMaltidVerksamhet([FromBody] MaltidVerksamhet maltidVerksamhet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MaltidVerksamhet.Add(maltidVerksamhet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaltidVerksamhet", new { id = maltidVerksamhet.ID }, maltidVerksamhet);
        }

        // DELETE: api/MaltidVerksamhet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaltidVerksamhet([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var maltidVerksamhet = await _context.MaltidVerksamhet.SingleOrDefaultAsync(m => m.ID == id);
            if (maltidVerksamhet == null)
            {
                return NotFound();
            }

            _context.MaltidVerksamhet.Remove(maltidVerksamhet);
            await _context.SaveChangesAsync();

            return Ok(maltidVerksamhet);
        }

        private bool MaltidVerksamhetExists(int id)
        {
            return _context.MaltidVerksamhet.Any(e => e.ID == id);
        }
    }
}
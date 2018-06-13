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
    [Route("api/MaltidPortionstyp")]
    public class MaltidPortionstypController : Controller
    {
        private readonly MaltidDbContext _context;

        public MaltidPortionstypController(MaltidDbContext context)
        {
            _context = context;
        }

        // GET: api/MaltidPortionstyp
        [HttpGet]
        public IEnumerable<MaltidPortionstyp> GetMaltidPortionstyp()
        {
            return _context.MaltidPortionstyp;
        }

        // GET: api/MaltidPortionstyp/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaltidPortionstyp([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var maltidPortionstyp = await _context.MaltidPortionstyp.SingleOrDefaultAsync(m => m.Portionstyp_ID == id);

            if (maltidPortionstyp == null)
            {
                return NotFound();
            }

            return Ok(maltidPortionstyp);
        }

        // PUT: api/MaltidPortionstyp/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaltidPortionstyp([FromRoute] string id, [FromBody] MaltidPortionstyp maltidPortionstyp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != maltidPortionstyp.Portionstyp_ID)
            {
                return BadRequest();
            }

            _context.Entry(maltidPortionstyp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaltidPortionstypExists(id))
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

        // POST: api/MaltidPortionstyp
        [HttpPost]
        public async Task<IActionResult> PostMaltidPortionstyp([FromBody] MaltidPortionstyp maltidPortionstyp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MaltidPortionstyp.Add(maltidPortionstyp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaltidPortionstyp", new { id = maltidPortionstyp.Portionstyp_ID }, maltidPortionstyp);
        }

        // DELETE: api/MaltidPortionstyp/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaltidPortionstyp([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var maltidPortionstyp = await _context.MaltidPortionstyp.SingleOrDefaultAsync(m => m.Portionstyp_ID == id);
            if (maltidPortionstyp == null)
            {
                return NotFound();
            }

            _context.MaltidPortionstyp.Remove(maltidPortionstyp);
            await _context.SaveChangesAsync();

            return Ok(maltidPortionstyp);
        }

        private bool MaltidPortionstypExists(string id)
        {
            return _context.MaltidPortionstyp.Any(e => e.Portionstyp_ID == id);
        }
    }
}
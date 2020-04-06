using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClientesTG.Models;
using Microsoft.AspNetCore.Authorization;

namespace ClientesTG.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LogradourosController : ControllerBase
    {
        private readonly JC_TH_TestContext _context;

        public LogradourosController(JC_TH_TestContext context)
        {
            _context = context;
        }

        // GET: api/Logradouros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Logradouros>>> GetLogradouros(int? ClienteId)
        {
            var logradouros = _context.Logradouros.AsQueryable();

            if (ClienteId != null)  
            {
                logradouros = _context.Logradouros.Where(i => i.ClienteId == ClienteId);
            }

            return await logradouros.ToListAsync();
        }

        // GET: api/Logradouros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Logradouros>> GetLogradouros(int id)
        {
            var logradouros = await _context.Logradouros.FindAsync(id);

            if (logradouros == null)
            {
                return NotFound();
            }

            return logradouros;
        }

        // PUT: api/Logradouros/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogradouros(int id, Logradouros logradouros)
        {
            if (id != logradouros.LogradouroId)
            {
                return BadRequest();
            }

            _context.Entry(logradouros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogradourosExists(id))
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

        // POST: api/Logradouros
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Logradouros>> PostLogradouros(Logradouros logradouros)
        {
            _context.Logradouros.Add(logradouros);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogradouros", new { id = logradouros.LogradouroId }, logradouros);
        }

        // DELETE: api/Logradouros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Logradouros>> DeleteLogradouros(int id)
        {
            var logradouros = await _context.Logradouros.FindAsync(id);
            if (logradouros == null)
            {
                return NotFound();
            }

            _context.Logradouros.Remove(logradouros);
            await _context.SaveChangesAsync();

            return logradouros;
        }

        private bool LogradourosExists(int id)
        {
            return _context.Logradouros.Any(e => e.LogradouroId == id);
        }
    }
}

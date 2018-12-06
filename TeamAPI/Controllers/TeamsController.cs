using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamAPI.Models;

namespace TeamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly TeamDataContext _context;

        public TeamsController(TeamDataContext context)
        {
            _context = context;
        }

        // GET: api/Teams
        [HttpGet]
        public IEnumerable<Teams> GetTeams()
        {
            return _context.Teams;
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeams([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teams = await _context.Teams.FindAsync(id);

            if (teams == null)
            {
                return NotFound();
            }

            return Ok(teams);
        }

        // PUT: api/Teams/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeams([FromRoute] int id, [FromBody] Teams teams)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teams.TeamsID)
            {
                return BadRequest();
            }

            _context.Entry(teams).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamsExists(id))
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

        // POST: api/Teams
        [HttpPost]
        public async Task<IActionResult> PostTeams([FromBody] Teams teams)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Teams.Add(teams);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeams", new { id = teams.TeamsID }, teams);
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeams([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teams = await _context.Teams.FindAsync(id);
            if (teams == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(teams);
            await _context.SaveChangesAsync();

            return Ok(teams);
        }

        private bool TeamsExists(int id)
        {
            return _context.Teams.Any(e => e.TeamsID == id);
        }
    }
}
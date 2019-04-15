using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.FineDesignCupcakes;
using DAL.FineDesignCupcakes.Models;

namespace API.FineDesignCupcakes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrostingsController : ControllerBase
    {
        private readonly FDCDatabaseContext _context;

        public FrostingsController(FDCDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Frostings
        [HttpGet]
        public IEnumerable<Frostings> GetFrostings()
        {
            return _context.Frostings;
        }

        // GET: api/Frostings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFrostings([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var frostings = await _context.Frostings.FindAsync(id);

            if (frostings == null)
            {
                return NotFound();
            }

            return Ok(frostings);
        }

        // PUT: api/Frostings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFrostings([FromRoute] int id, [FromBody] Frostings frostings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != frostings.FrostingId)
            {
                return BadRequest();
            }

            _context.Entry(frostings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FrostingsExists(id))
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

        // POST: api/Frostings
        [HttpPost]
        public async Task<IActionResult> PostFrostings([FromBody] Frostings frostings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Frostings.Add(frostings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFrostings", new { id = frostings.FrostingId }, frostings);
        }

        // DELETE: api/Frostings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFrostings([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var frostings = await _context.Frostings.FindAsync(id);
            if (frostings == null)
            {
                return NotFound();
            }

            _context.Frostings.Remove(frostings);
            await _context.SaveChangesAsync();

            return Ok(frostings);
        }

        private bool FrostingsExists(int id)
        {
            return _context.Frostings.Any(e => e.FrostingId == id);
        }
    }
}
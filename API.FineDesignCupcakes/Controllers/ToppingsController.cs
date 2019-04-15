﻿using System;
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
    public class ToppingsController : ControllerBase
    {
        private readonly FDCDatabaseContext _context;

        public ToppingsController(FDCDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Toppings
        [HttpGet]
        public IEnumerable<Toppings> GetToppings()
        {
            return _context.Toppings;
        }

        // GET: api/Toppings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetToppings([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var toppings = await _context.Toppings.FindAsync(id);

            if (toppings == null)
            {
                return NotFound();
            }

            return Ok(toppings);
        }

        // PUT: api/Toppings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToppings([FromRoute] int id, [FromBody] Toppings toppings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toppings.ToppingId)
            {
                return BadRequest();
            }

            _context.Entry(toppings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToppingsExists(id))
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

        // POST: api/Toppings
        [HttpPost]
        public async Task<IActionResult> PostToppings([FromBody] Toppings toppings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Toppings.Add(toppings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToppings", new { id = toppings.ToppingId }, toppings);
        }

        // DELETE: api/Toppings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToppings([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var toppings = await _context.Toppings.FindAsync(id);
            if (toppings == null)
            {
                return NotFound();
            }

            _context.Toppings.Remove(toppings);
            await _context.SaveChangesAsync();

            return Ok(toppings);
        }

        private bool ToppingsExists(int id)
        {
            return _context.Toppings.Any(e => e.ToppingId == id);
        }
    }
}
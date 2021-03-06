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
    public class FlavorsController : ControllerBase
    {
        private readonly FDCDatabaseContext _context;

        public FlavorsController(FDCDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Flavors
        [HttpGet]
        public IEnumerable<Flavors> GetFlavors()
        {
            return _context.Flavors;
        }

        // GET: api/Flavors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlavors([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flavors = await _context.Flavors.FindAsync(id);

            if (flavors == null)
            {
                return NotFound();
            }

            return Ok(flavors);
        }

        // PUT: api/Flavors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlavors([FromRoute] int id, [FromBody] Flavors flavors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flavors.FlavorId)
            {
                return BadRequest();
            }

            _context.Entry(flavors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlavorsExists(id))
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

        // POST: api/Flavors
        [HttpPost]
        public async Task<IActionResult> PostFlavors([FromBody] Flavors flavors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Flavors.Add(flavors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlavors", new { id = flavors.FlavorId }, flavors);
        }

        // DELETE: api/Flavors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlavors([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flavors = await _context.Flavors.FindAsync(id);
            if (flavors == null)
            {
                return NotFound();
            }

            _context.Flavors.Remove(flavors);
            await _context.SaveChangesAsync();

            return Ok(flavors);
        }

        private bool FlavorsExists(int id)
        {
            return _context.Flavors.Any(e => e.FlavorId == id);
        }
    }
}
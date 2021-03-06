﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GDayMateBackend.Data;

namespace GDayMateBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganisationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrganisationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Organisations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organisation>>> GetOrganisations()
        {
            return await _context.Organisations.ToListAsync();
        }

        // GET: api/Organisations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Organisation>> GetOrganisation(long id)
        {
            var organisation = await _context.Organisations.FindAsync(id);

            if (organisation == null)
            {
                return NotFound();
            }

            return organisation;
        }

        // PUT: api/Organisations/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganisation(long id, Organisation organisation)
        {
            if (id != organisation.Id)
            {
                return BadRequest();
            }

            _context.Entry(organisation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganisationExists(id))
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

        // POST: api/Organisations
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Organisation>> PostOrganisation(Organisation organisation)
        {
            _context.Organisations.Add(organisation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganisation", new { id = organisation.Id }, organisation);
        }

        // DELETE: api/Organisations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Organisation>> DeleteOrganisation(long id)
        {
            var organisation = await _context.Organisations.FindAsync(id);
            if (organisation == null)
            {
                return NotFound();
            }

            _context.Organisations.Remove(organisation);
            await _context.SaveChangesAsync();

            return organisation;
        }

        private bool OrganisationExists(long id)
        {
            return _context.Organisations.Any(e => e.Id == id);
        }

        /// <summary>
        /// Get a list of matching users for this organisation
        /// </summary>
        /// <param name="oid">ID of the organisation</param>
        /// <returns>A list of users who share the same postcode and has needs the organisation can fulfil</returns>
        [HttpGet("{oid}/matches")]
        public async Task<ActionResult<IEnumerable<User>>> GetMatchingUsers(long oid)
        {
            var organisation = await _context.Organisations.FindAsync(oid);

            var localUsers = await _context.Users
                .Where(u => u.Location == organisation.Location)
                .ToListAsync();

            var matchUsers = new List<User>();
            foreach (var u in localUsers)
            foreach(var n in u.Needs)
                if(organisation.Services.Contains(n))
                    matchUsers.Add(u);

            return Ok(matchUsers);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AirCesiModel.Context;
using AirCesiModel.Entities;
using Microsoft.AspNetCore.Authorization;

namespace AirCesiAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompagniesController : ControllerBase
    {
        private readonly AirCesiContext _context;

        public CompagniesController(AirCesiContext context)
        {
            _context = context;
        }

        // GET: api/Compagnies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compagnie>>> GetCompagnies()
        {
            return await _context.Compagnies.ToListAsync();
        }

        // GET: api/Compagnies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Compagnie>> GetCompagnie(int id)
        {
            var compagnie = await _context.Compagnies.FindAsync(id);

            if (compagnie == null)
            {
                return NotFound();
            }

            return compagnie;
        }

        
    }
}

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
    public class AeroportsController : ControllerBase
    {
        private readonly AirCesiContext _context;

        public AeroportsController(AirCesiContext context)
        {
            _context = context;
        }

        // GET: api/Aeroports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aeroport>>> GetAeroports()
        {
            return await _context.Aeroports.Include(a => a.Villes).ToListAsync();
        }

        // GET: api/Aeroports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aeroport>> GetAeroport(int id)
        {
            var aeroport = await _context.Aeroports.FindAsync(id);

            if (aeroport == null)
            {
                return NotFound();
            }

            return aeroport;
        }

    }
}

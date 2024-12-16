using AirCesiModel.Context;
using AirCesiModel.Dto;
using AirCesiModel.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirCesiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolsController : ControllerBase
    {
        private readonly AirCesiContext _context;

        public VolsController(AirCesiContext context)
        {
            _context = context;
        }

        // GET: api/Vols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VolDto>>> GetVols()
        {
            return await _context.Vols.Select(vol => new VolDto
            {
                Id = vol.Id,
                DateArrivee = vol.DateArrivee,
                DateDepart = vol.DateDepart,
                EstOuvert = vol.EstOuvert,
            }).ToListAsync();
        }

        // GET: api/Vols/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VolDto>> GetVol(int id)
        {
            var vol = await _context.Vols                
                .Include(v => v.AeroportDepart)
                .Include(v => v.AeroportArrivee)
                .Include(v => v.Compagnie)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (vol == null)
            {
                return NotFound();
            }

            return new VolDto
            {
                Id = vol.Id,
                DateArrivee = vol.DateArrivee,
                DateDepart = vol.DateDepart,
                EstOuvert = vol.EstOuvert,  
                CompagnieName = vol.Compagnie?.Nom ,
                AeroportArrivee = vol.AeroportArrivee?.Nom,
                AeroportDepart = vol.AeroportDepart?.Nom
            };
        }

        // PUT: api/Vols/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVol(int id, Vol vol)
        {
            if (id != vol.Id)
            {
                return BadRequest();
            }

            _context.Entry(vol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolExists(id))
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

        // POST: api/Vols
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vol>> PostVol(Vol vol)
        {
            _context.Vols.Add(vol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVol", new { id = vol.Id }, vol);
        }

        // DELETE: api/Vols/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVol(int id)
        {
            var vol = await _context.Vols.FindAsync(id);
            if (vol == null)
            {
                return NotFound();
            }

            _context.Vols.Remove(vol);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VolExists(int id)
        {
            return _context.Vols.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Articulos.Data;
using Api_Articulos.Models;

namespace Api_Articulos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupacionController : ControllerBase
    {
        private readonly Contexto _context;

        public OccupacionController(Contexto context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ocupacion>>> GetOcupacion()
        {
            return await _context.Ocupacions.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Ocupacion>> GetOcupacion(int id)
        {
            var ocupacion = await _context.Ocupacions.FindAsync(id);

            if (ocupacion == null)
            {
                return NotFound();
            }

            return ocupacion;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutOcupacion(int id, Ocupacion ocupacion)
        {
            if (id != ocupacion.OcupacionId)
            {
                return BadRequest();
            }

            _context.Entry(ocupacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticulosExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Ocupacion>> PostOcupacion(Ocupacion ocupacion)
        {
            _context.Ocupacions.Add(ocupacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOcupacion", new { id = ocupacion.OcupacionId }, ocupacion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOcupacion(int id)
        {
            var ocupacion = await _context.Ocupacions.FindAsync(id);
            if (ocupacion == null)
            {
                return NotFound();
            }

            _context.Ocupacions.Remove(ocupacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArticulosExists(int id)
        {
            return _context.Ocupacions.Any(e => e.OcupacionId == id);
        }
    }
}
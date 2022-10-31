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
    public class PersonaController : ControllerBase
    {
        private readonly Contexto _context;

        public PersonaController(Contexto context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personas>>> GetPersona()
        {
            return await _context.Personas.ToListAsync();
        }

        [HttpGet("{id}")]
     
        public async Task<ActionResult<Personas>> GetPersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(int id, Personas personas)
        {
            if (id != personas.PersonaId)
            {
                return BadRequest();
            }

            _context.Entry(personas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
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
        public async Task<ActionResult<Personas>> PostPersona(Personas personas)
        {
            _context.Personas.Add(personas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersona", new { id = personas.PersonaId }, personas);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.PersonaId == id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Api_Articulos.Models
{
    public class Personas
    {
        [Key]
        public int PersonaId { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Celular { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        public string? FechaNacimiento { get; set; }
        public string? Ocupacion { get; set; }
        public double Balance { get; set; }
    }
}
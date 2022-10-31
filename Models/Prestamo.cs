using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Api_Articulos.Models
{
    public class Prestamo
    {
        [Key]
        public int PrestamoId { get; set; }
        public string? Fecha { get; set; }
        public string? FechaVencimiento { get; set; }
        public string? Persona { get; set; }
        public string? Concepto { get; set; }
        public double Monto { get; set; }
        public double Balance { get; set; }
    }
}
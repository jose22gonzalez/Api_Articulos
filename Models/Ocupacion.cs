using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Api_Articulos.Models
{
    public class Ocupacion
    {
        [Key]
        public int OcupacionId { get; set; }
        public string? Descripcion { get; set; }
        public double Salario { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api_Articulos.Models;


namespace Api_Articulos.Data
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options): base(options){
            
        }

        public DbSet<Articulos> Articulos {get; set;}
        public DbSet<Ocupacion> Ocupacions { get; set; }
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
    }
}
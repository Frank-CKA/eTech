using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proyecto1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; } //Added db sets - Sábado 14

        public DbSet<Marca> Marcas { get; set; } //Added db sets - Sábado 14

        public DbSet<Producto> Productos { get; set; } //Added db sets - Sábado 14

        public DbSet<UsuarioAplicacion> UsuarioAplicacion { get; set; } //Added db sets - Sábado 14

    }
}

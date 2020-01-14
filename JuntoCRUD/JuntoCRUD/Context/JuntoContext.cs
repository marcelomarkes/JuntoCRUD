using JuntoCRUD.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuntoCRUD.Context
{
    public class JuntoContext : DbContext
    {
        public JuntoContext(DbContextOptions<JuntoContext> options) : base(options)
        {

        }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Usuario>().HasKey(p => p.IdUsuario);
            modelBuilder.Entity<Usuario>().Property(p => p.IdUsuario).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Usuario>().Property(p => p.LoginUsuario).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Usuario>().Property(p => p.SenhaUsuario).IsRequired().HasMaxLength(50);
        }
    }
}

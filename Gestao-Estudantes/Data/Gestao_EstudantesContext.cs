using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gestao_Estudantes.Models;

namespace Gestao_Estudantes.Data
{
    public class Gestao_EstudantesContext : DbContext
    {
        public Gestao_EstudantesContext (DbContextOptions<Gestao_EstudantesContext> options)
            : base(options)
        {
        }
        public DbSet<Gestao_Estudantes.Models.Estudante> Estudantes { get; set; } 
        public DbSet<Gestao_Estudantes.Models.Curso> Cursos { get; set; }
        public DbSet<Gestao_Estudantes.Models.Inscricao> Inscricaos { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity < Estudante >().ToTable("Estudante");
            modelBuilder.Entity < Curso >().ToTable("Curso");
            modelBuilder.Entity< Inscricao >().ToTable("Inscricao");
        }
    }
}

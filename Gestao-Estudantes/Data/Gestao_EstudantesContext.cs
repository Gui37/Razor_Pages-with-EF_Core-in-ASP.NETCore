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
        public DbSet<Gestao_Estudantes.Models.Departamento> Departamentos { get; set; }
        public DbSet<Gestao_Estudantes.Models.Docente> Docentes { get; set; }
        public DbSet<Gestao_Estudantes.Models.AtribuicaoEscritorio> AtribuicaoEscritorios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>().ToTable(nameof(Curso))
                 .HasMany(c => c.Docentes)
                 .WithMany(i => i.Cursos);
            modelBuilder.Entity<Estudante>().ToTable(nameof(Estudante));
            modelBuilder.Entity<Docente>().ToTable(nameof(Docente));
        }

        public DbSet<Gestao_Estudantes.Models.EstudanteVM> EstudanteVM { get; set; } = default!;
    }
}

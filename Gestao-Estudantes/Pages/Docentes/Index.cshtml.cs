using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gestao_Estudantes.Data;
using Gestao_Estudantes.Models;
using Gestao_Estudantes.Models.GestaoViewModels;

namespace Gestao_Estudantes.Pages.Docentes
{
    public class IndexModel : PageModel
    {
        private readonly Gestao_Estudantes.Data.Gestao_EstudantesContext _context;

        public IndexModel(Gestao_Estudantes.Data.Gestao_EstudantesContext context)
        {
            _context = context;
        }

        public DocenteIndexData DocenteData { get; set; }
        public int DocenteID { get; set; }
        public int CursoID { get; set; }

        public async Task OnGetAsync(int? id, int? cursoID)
        {
            DocenteData = new DocenteIndexData();
            DocenteData.Docentes = await _context.Docentes
                .Include(i => i.AtribuicaoEscritorio)
                .Include(i => i.Cursos)
                    .ThenInclude(c => c.Departamento)
                .OrderBy(i => i.Apelido)
                .ToListAsync();

            if (id != null) { 
            DocenteID = id.Value;
            Docente docente = DocenteData.Docentes
                .Where(i => i.Id == id.Value).Single();
            DocenteData.Cursos = docente.Cursos;
            }
            if (cursoID != null)
            {
                CursoID = cursoID.Value;
                IEnumerable <Inscricao> Inscricaos = await _context.Inscricaos
                    .Where(x => x.CursoID == CursoID)
                    .Include(i => i.Estudante)
                    .ToListAsync();
                DocenteData.Inscricaos = Inscricaos;
            }
        }
    }
}

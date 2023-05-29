using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gestao_Estudantes.Data;
using Gestao_Estudantes.Models;

namespace Gestao_Estudantes.Pages.Estudantes
{
    public class DetailsModel : PageModel
    {
        private readonly Gestao_Estudantes.Data.Gestao_EstudantesContext _context;

        public DetailsModel(Gestao_Estudantes.Data.Gestao_EstudantesContext context)
        {
            _context = context;
        }

      public Estudante Estudante { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Estudantes == null)
            {
                return NotFound();
            }

            Estudante = await _context.Estudantes.
                Include(s => s.Inscricaos)
                .ThenInclude(e => e.Curso)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (Estudante == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

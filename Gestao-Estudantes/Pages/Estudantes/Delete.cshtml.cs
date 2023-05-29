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
    public class DeleteModel : PageModel
    {
        private readonly Gestao_Estudantes.Data.Gestao_EstudantesContext _context;

        public DeleteModel(Gestao_Estudantes.Data.Gestao_EstudantesContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Estudante Estudante { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Estudantes == null)
            {
                return NotFound();
            }

            var estudante = await _context.Estudantes.FirstOrDefaultAsync(m => m.ID == id);

            if (estudante == null)
            {
                return NotFound();
            }
            else 
            {
                Estudante = estudante;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Estudantes == null)
            {
                return NotFound();
            }
            var estudante = await _context.Estudantes.FindAsync(id);

            if (estudante != null)
            {
                Estudante = estudante;
                _context.Estudantes.Remove(Estudante);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

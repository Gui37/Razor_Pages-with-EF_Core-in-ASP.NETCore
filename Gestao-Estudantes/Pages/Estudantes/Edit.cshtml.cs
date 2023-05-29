using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestao_Estudantes.Data;
using Gestao_Estudantes.Models;

namespace Gestao_Estudantes.Pages.Estudantes
{
    public class EditModel : PageModel
    {
        private readonly Gestao_Estudantes.Data.Gestao_EstudantesContext _context;

        public EditModel(Gestao_Estudantes.Data.Gestao_EstudantesContext context)
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

            var estudante =  await _context.Estudantes.FirstOrDefaultAsync(m => m.ID == id);
            if (estudante == null)
            {
                return NotFound();
            }
            Estudante = estudante;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Estudante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudanteExists(Estudante.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EstudanteExists(int id)
        {
          return (_context.Estudantes?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}

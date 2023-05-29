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

        public async Task<IActionResult> OnGetAsync(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            Estudante = await _context.Estudantes.FindAsync(Id);

            if (Estudante == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? Id)
        {
            var estudanteToUpdate = await _context.Estudantes.FindAsync(Id);

            if (estudanteToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Estudante>(
                estudanteToUpdate,
                "estudante",
                s => s.Nome, s => s.Apelido, s => s.DataInscricao))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}

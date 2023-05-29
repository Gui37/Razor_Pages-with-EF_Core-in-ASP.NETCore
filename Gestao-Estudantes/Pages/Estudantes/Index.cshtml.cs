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
    public class IndexModel : PageModel
    {
        private readonly Gestao_Estudantes.Data.Gestao_EstudantesContext _context;

        public IndexModel(Gestao_Estudantes.Data.Gestao_EstudantesContext context)
        {
            _context = context;
        }

        public IList<Estudante> Estudante { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Estudantes != null)
            {
                Estudante = await _context.Estudantes.ToListAsync();
            }
        }
    }
}

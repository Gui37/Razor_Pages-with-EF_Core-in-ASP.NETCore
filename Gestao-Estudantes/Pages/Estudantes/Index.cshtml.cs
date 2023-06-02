using Gestao_Estudantes.Data;
using Gestao_Estudantes.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gestao_Estudantes.Pages.Estudantes
{
    public class IndexModel : PageModel
    {
        private readonly Gestao_EstudantesContext _context;
        private readonly IConfiguration Configuration;


        public IndexModel(Gestao_EstudantesContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string? NomeOrdem { get; set; }
        public string? DataOrdem { get; set; }
        public string? FiltroActual { get; set; }
        public string? OrdemActual { get; set; }

        public ListaPaginada<Estudante> Estudantes { get; set; }
        public async Task OnGetAsync(string ordemFiltro, string searchFiltro, string filtroActual, int? indexPagina)
        {
            NomeOrdem = String.IsNullOrEmpty(ordemFiltro) ? "nome_desc" : "";
            DataOrdem = ordemFiltro == "date" ? "data_desc" : "date";

            if (searchFiltro != null)
            {
                indexPagina = 1;
            }
            else
            {
                searchFiltro = filtroActual;
            }

            FiltroActual = searchFiltro;

            IQueryable<Estudante> estudanteIQ = from s in _context.Estudantes
                                                select s;
            if (!String.IsNullOrEmpty(searchFiltro))
            {
                estudanteIQ = estudanteIQ.Where(s => s.Apelido.Contains(searchFiltro) ||
                s.Nome.Contains(searchFiltro));
            }

            estudanteIQ = ordemFiltro switch
            {
                "nome_desc" => estudanteIQ.OrderByDescending(s => s.Apelido),
                "date" => estudanteIQ.OrderBy(s => s.DataInscricao),
                "data_desc" => estudanteIQ.OrderByDescending(s => s.DataInscricao),
                _ => estudanteIQ.OrderByDescending(s => s.Apelido),
            };
            var tamanhoPagina = Configuration.GetValue("PageSize", 4);
            Estudantes = await ListaPaginada<Estudante>.CreateAsync(
                estudanteIQ.AsNoTracking(), indexPagina ?? 1, tamanhoPagina);
        }
    }
}

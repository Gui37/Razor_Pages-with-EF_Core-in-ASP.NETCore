using Microsoft.EntityFrameworkCore;

namespace Gestao_Estudantes
{
    public class ListaPaginada<T> : List<T>
    {
        public int IndexPagina { get; private set; }
        public int PaginaTotal { get; private set; }

        public ListaPaginada(List<T> items, int count, int indexPagina, int tamanhoPagina)
        {
            IndexPagina = indexPagina;
            PaginaTotal = (int)Math.Ceiling(count / (double)tamanhoPagina);

            this.AddRange(items);
        }

        public bool HasPreviousPage => IndexPagina > 1;

        public bool HasNextPage => IndexPagina < PaginaTotal;

        public static async Task<ListaPaginada<T>> CreateAsync(
            IQueryable<T> source, int indexPagina, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip(
                (indexPagina - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return new ListaPaginada<T>(items, count, indexPagina, pageSize);
        }
    }
}       

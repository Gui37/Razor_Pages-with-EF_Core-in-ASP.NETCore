namespace Gestao_Estudantes.Models.GestaoViewModels
{
    public class DocenteIndexData
    {
        public IEnumerable<Docente> Docentes { get; set; }
        public IEnumerable<Curso> Cursos { get; set; }
        public IEnumerable<Inscricao> Inscricaos { get; set; }
    }
}

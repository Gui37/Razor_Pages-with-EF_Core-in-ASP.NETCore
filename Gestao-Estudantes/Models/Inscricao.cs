using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Gestao_Estudantes.Models
{
    public enum Nota
    {
        A,B,C,E,D,F
    }
    public class Inscricao
    {
        public int InscricaoID { get; set; }
        public int CursoID { get; set; }
        public int EstudanteID { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public Nota? Nota { get; set; }

        public Curso? Curso { get; set; }
        public Estudante? Estudante { get; set; }

    }
}

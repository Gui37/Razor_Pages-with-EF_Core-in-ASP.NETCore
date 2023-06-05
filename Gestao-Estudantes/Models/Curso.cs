using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestao_Estudantes.Models
{
    public class Curso
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Número")]
        public int CursoID { get; set; }

        [StringLength(50, MinimumLength =2)]
        public string? NomeC { get; set; }

        [Range(0,5)]
        public int Pontuacao { get; set; }

        public int DepartmentoID { get; set; }

        public Departamento Departamento { get; set; }
        public ICollection<Inscricao> Inscricaos { get; set; }
        public ICollection<Docente> Docentes { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestao_Estudantes.Models
{
    public class Docente
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Apelido")]
        [StringLength(50)]
        public string Apelido { get; set; }

        [Required]
        [Column("Nome")]
        [Display(Name = "Nome")]
        [StringLength(50)]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name ="Data do Contrato")]
        public DateTime DataContrato { get; set; }

        public string NomeCompleto
        {
            get
            {
                return Nome + ", " + Apelido;
            }
        }

        public ICollection<Curso> Cursos { get; set; }
        public AtribuicaoEscritorio AtribuicaoEscritorio { get; set; }
    }
}

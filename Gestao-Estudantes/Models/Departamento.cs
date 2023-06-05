using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Gestao_Estudantes.Models
{
    public class Departamento
    {
        [Key]
        public int? DepartmentoID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Orcamento { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Início")]
        public DateTime DataInicio { get; set; }

        public int? DoocenteID { get; set; }

        public Docente Administrador { get; set; }
        public ICollection<Curso> Cursos { get; set; }
    }
}

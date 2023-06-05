using System.ComponentModel.DataAnnotations;

namespace Gestao_Estudantes.Models
{
    public class AtribuicaoEscritorio
    {
        [Key]
        public int DocenteID { get; set; }
        [StringLength(50)]
        [Display(Name = "Localização do Escritório")]
        public string Localizacao { get; set; }

        public Docente Docente { get; set; }
    }
}

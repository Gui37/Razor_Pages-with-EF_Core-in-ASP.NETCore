using System.ComponentModel.DataAnnotations;
namespace Gestao_Estudantes.Models
{
    public class Estudante
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[A-Z] + [a-zA-Z]*$")]
        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[A-Z] + [a-zA-Z]*$")]
        [Display(Name = "Apelido")]
        public string? Apelido { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Inscrição")]
        public DateTime DataInscricao { get; set; }


        public string NomeCompleto
        {
            get
            {
                return Nome + ", " + Apelido;
            }
        }

        public ICollection<Inscricao>? Inscricaos { get; set; }
    }
}

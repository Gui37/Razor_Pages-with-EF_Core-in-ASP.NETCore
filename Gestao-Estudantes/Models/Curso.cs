using System.ComponentModel.DataAnnotations.Schema;

namespace Gestao_Estudantes.Models
{
    public class Curso
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string? NomeC { get; set; }
        public int Pontuacao { get; set; }
    }
}

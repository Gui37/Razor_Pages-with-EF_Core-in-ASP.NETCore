namespace Gestao_Estudantes.Models
{
    public class EstudanteVM
    {
        public int ID { get; set; }
        public string? Nome { get; set; }
        public string? Apelido { get; set; }
        public DateTime DataInscricao { get; set; }
    }
}

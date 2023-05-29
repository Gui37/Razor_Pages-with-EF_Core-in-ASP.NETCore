namespace Gestao_Estudantes.Models
{
    public class Estudante
    {
        public int ID { get; set; }
        public string? Nome { get; set; }
        public string? Apelido { get; set; }
        public DateTime DataInscricao { get; set; }

        public ICollection<Inscricao>? Inscricaos { get; set; }
    }
}

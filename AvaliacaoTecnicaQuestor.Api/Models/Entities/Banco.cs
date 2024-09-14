namespace AvaliacaoTecnicaQuestor.Api.Models.Entities
{
    public class Banco
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public double PercentualJuros { get; set; }
    }
}

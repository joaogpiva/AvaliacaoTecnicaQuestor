namespace AvaliacaoTecnicaQuestor.Api.Models
{
    public class Banco
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public double PercentualJuros { get; set; }
        public ICollection<Boleto> Boletos { get; set; }
    }
}

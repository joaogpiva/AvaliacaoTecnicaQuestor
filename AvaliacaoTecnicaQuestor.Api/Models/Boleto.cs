namespace AvaliacaoTecnicaQuestor.Api.Models
{
    public class Boleto
    {
        public long Id { get; set; }
        public string NomePagador { get; set; }
        public string IdentificacaoPagador { get; set; }
        public string NomeBeneficiario { get; set; }
        public string IdentificacaoBeneficiario { get; set; }
        public double Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string? Observacao { get; set; }
        public Banco Banco { get; set; }
    }
}

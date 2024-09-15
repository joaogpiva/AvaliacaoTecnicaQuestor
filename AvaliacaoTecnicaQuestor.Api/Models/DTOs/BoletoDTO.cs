using AvaliacaoTecnicaQuestor.Api.Models.Entities;

namespace AvaliacaoTecnicaQuestor.Api.Models.DTOs
{
    public class BoletoDTO
    {
        public string NomePagador { get; set; }
        public string IdentificacaoPagador { get; set; }
        public string NomeBeneficiario { get; set; }
        public string IdentificacaoBeneficiario { get; set; }
        public double Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string? Observacao { get; set; }
        public long BancoId { get; set; }
    }
}

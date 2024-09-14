using System.ComponentModel.DataAnnotations;

namespace AvaliacaoTecnicaQuestor.Api.Models.DTOs
{
    public class BancoDTO
    {
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public double PercentualJuros { get; set; }
    }
}

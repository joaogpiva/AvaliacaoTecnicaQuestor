using AvaliacaoTecnicaQuestor.Api.Models.DTOs;
using AvaliacaoTecnicaQuestor.Api.Models.Entities;

namespace AvaliacaoTecnicaQuestor.Api.Services
{
    public interface IBoletoService
    {
        Task<Boleto> PostBoletoAsync(BoletoDTO boletoDTO);
        Task<Boleto?> GetBoletoByIdAsync(long id);
    }
}

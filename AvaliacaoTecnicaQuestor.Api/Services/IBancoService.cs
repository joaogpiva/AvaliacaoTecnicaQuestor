using AvaliacaoTecnicaQuestor.Api.Models.DTOs;
using AvaliacaoTecnicaQuestor.Api.Models.Entities;

namespace AvaliacaoTecnicaQuestor.Api.Services
{
    public interface IBancoService
    {
        Task<List<Banco>> GetBancosAsync();
        Task<Banco?> GetBancoByCodigoAsync(string codigo);
        Task<Banco> PostBancoAsync(BancoDTO bancoDTO);
    }
}

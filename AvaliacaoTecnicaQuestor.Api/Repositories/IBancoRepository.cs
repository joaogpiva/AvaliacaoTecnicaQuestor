using AvaliacaoTecnicaQuestor.Api.Models.Entities;

namespace AvaliacaoTecnicaQuestor.Api.Repositories
{
    public interface IBancoRepository
    {
        Task<List<Banco>> GetBancosAsync();
        Task<Banco?> GetBancoByCodigoAsync(string codigo);
        Task<Banco> CreateBancoAsync(Banco banco);
    }
}

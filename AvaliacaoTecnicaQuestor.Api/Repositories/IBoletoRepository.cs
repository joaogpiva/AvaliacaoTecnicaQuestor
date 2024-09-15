using AvaliacaoTecnicaQuestor.Api.Models.Entities;

namespace AvaliacaoTecnicaQuestor.Api.Repositories
{
    public interface IBoletoRepository
    {
        Task<Boleto?> GetBoletoByIdAsync(long id);
        Task<Boleto> CreateBoletoAsync(Boleto boleto);
    }
}

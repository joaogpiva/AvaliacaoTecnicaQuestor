using AvaliacaoTecnicaQuestor.Api.Data;
using AvaliacaoTecnicaQuestor.Api.Models.Entities;

namespace AvaliacaoTecnicaQuestor.Api.Repositories
{
    public class BoletoRepository : IBoletoRepository
    {
        private readonly AppDbContext _context;

        public BoletoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Boleto?> GetBoletoByIdAsync(long id)
        {
            return await _context.Boletos.FindAsync(id);
        }

        public async Task<Boleto> CreateBoletoAsync(Boleto boleto)
        {
            await _context.Boletos.AddAsync(boleto);
            await _context.SaveChangesAsync();

            return boleto;
        }
    }
}

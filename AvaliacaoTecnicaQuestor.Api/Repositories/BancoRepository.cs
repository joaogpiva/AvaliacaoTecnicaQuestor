using AvaliacaoTecnicaQuestor.Api.Data;
using AvaliacaoTecnicaQuestor.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoTecnicaQuestor.Api.Repositories
{
    public class BancoRepository : IBancoRepository
    {
        private readonly AppDbContext _context;

        public BancoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Banco>> GetBancosAsync()
        {
            return await _context.Bancos.ToListAsync();
        }

        public async Task<Banco?> GetBancoByCodigoAsync(string codigo)
        {
            return await _context.Bancos.Where(b => b.Codigo == codigo).FirstOrDefaultAsync();
        }

        public async Task<Banco> CreateBancoAsync(Banco banco)
        {
            await _context.Bancos.AddAsync(banco);
            await _context.SaveChangesAsync();

            return banco;
        }
    }
}

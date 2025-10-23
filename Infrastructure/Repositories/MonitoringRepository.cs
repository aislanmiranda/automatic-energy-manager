using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MonitoringRepository : IMonitoringRepository
    {
        protected readonly AppDbContext _context;

        public MonitoringRepository(AppDbContext context)
            => _context = context;
        
        public async Task<List<Monitoring>?> GetMonitorings(Guid customerId,Guid equipamentId,
            CancellationToken cancellationToken)
        {
            var list = await _context
                                .Set<Monitoring>()
                                .Where(p => p.CustomerId == customerId && p.EquipamentId == equipamentId)
                                .ToListAsync(cancellationToken);
            return list;
        }
    }
}


using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EquipamentRepository : IEquipamentRepository
    {
        protected readonly AppDbContext _context;

        public EquipamentRepository(AppDbContext context)
            => _context = context;

        public async Task<Equipament> InsertAsync(Equipament entity, CancellationToken cancellationToken)
        {
            _context.Set<Equipament>().Add(entity);

            var save = await _context.SaveChangesAsync(cancellationToken);

            var existingEntity = await _context.Set<Equipament>()
                .FirstOrDefaultAsync(e => e.Id == entity.Id);

            if (existingEntity == null)
                throw new KeyNotFoundException("Entity not found.");

            return existingEntity;
        }

        public async Task<Equipament> UpdateAsync(Equipament entity, CancellationToken cancellationToken)
        {
            var model = _context.Update(entity).Entity;
            await _context.SaveChangesAsync(cancellationToken);
            return model;
        }

        public async Task<List<Equipament>?> GetAllByCustomerId(Guid customerId,
            CancellationToken cancellationToken)
        {
            var list = await _context
                                .Set<Equipament>()
                                .Include("Tasks")
                                .Where(p => p.CustomerId == customerId)
                                .ToListAsync(cancellationToken);
            return list;
        }
        
        public async Task<Equipament> GetEquipamentById(Guid equipamentId,
            CancellationToken cancellationToken)
        {
            var equipament = await _context
                                .Set<Equipament>()
                                .Where(p => p.Id == equipamentId)
                                .FirstOrDefaultAsync(cancellationToken);
            return equipament!;
        }
    }
}


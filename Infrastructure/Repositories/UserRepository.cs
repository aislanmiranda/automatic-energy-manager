using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
            => _context = context;

        public async Task<Guid> InsertAsync(User user)
        {
            _context.Set<User>().Add(user);

            var save = await _context.SaveChangesAsync();

            var existingEntity = await _context.Set<User>()
                .FirstOrDefaultAsync(e => e.Id == user.Id);

            return existingEntity == null ?
                throw new KeyNotFoundException("Entity not found.") : existingEntity.Id;
        }

        public async Task<User> AuthAsync(Expression<Func<User, bool>> filter, CancellationToken cancellationToken)
        {
            var user = await _context
                           .Set<User>()
                           .Where(filter)
                           .Include(c => c.UserCustomer!.Customer)
                           .FirstOrDefaultAsync(cancellationToken);
            return user!;
        }

        public async Task<User> UpdateStusAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await _context
                           .Set<User>()
                           .Where(p => p.Id == id)
                           .FirstOrDefaultAsync(cancellationToken);

            user!.SetStatus(1);

            var model = _context.Update(user).Entity;
            await _context.SaveChangesAsync(cancellationToken);
            return model;
        }

    }
}


using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class UserCustomerRepository : IUserCustomerRepository
    {
        protected readonly AppDbContext _context;

        public UserCustomerRepository(AppDbContext context)
            => _context = context;

        public async Task<UserCustomer> InsertAsync(UserCustomer usercustomer)
        {
            _context.Set<UserCustomer>().Add(usercustomer);

            await _context.SaveChangesAsync();

            return usercustomer;
        }
        
    }
}


using System;
using System.Linq.Expressions;
using System.Threading;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
            => _context = context;

        public Task<bool> ExistsCustomerToDocument(string documento)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer?> GetIdAsync(Guid id, CancellationToken cancellationToken)
            => await _context.Customers
                .Include(p => p.UserCustomer!.User)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task<Guid> InsertAsync(Customer customer, CancellationToken cancellationToken)
        {
            _context.Set<Customer>().Add(customer);

            var save = await _context.SaveChangesAsync(cancellationToken);

            var existingEntity = await _context.Set<Customer>()
                .FirstOrDefaultAsync(e => e.Id == customer.Id);

            if (existingEntity == null)
                throw new KeyNotFoundException("Entity not found.");

            return existingEntity.Id;
        }

        public async Task<Customer> UpdateAsync(Customer entity,CancellationToken cancellationToken)
        {
            var model = _context.Update(entity).Entity;
            await _context.SaveChangesAsync(cancellationToken);
            return model;
        }

        //public async Task<List<Customer>?> GetAll(Expression<Func<Customer, bool>> filter, CancellationToken cancellationToken)
        //{
        //    var list = await _context
        //                        .Set<Customer>()
        //                        .Where(filter)
        //                        .Include(c => c.UserCustomer!.User)                                
        //                        .ToListAsync(cancellationToken);
        //    return list;
        //}

        public async Task<List<Customer>?> GetAll(CancellationToken cancellationToken)
        {
            var list = await _context
                                .Set<Customer>()
                                .Include(c => c.UserCustomer!.User)
                                .Include(c => c.Equipaments)
                                .ToListAsync(cancellationToken);
            return list;
        }
    }
}


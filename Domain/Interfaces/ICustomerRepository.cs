using Domain.Entities;

namespace Domain.Interfaces
{
	public interface ICustomerRepository
	{
        Task<bool> ExistsCustomerToDocument(string documento);
        Task<Guid> InsertAsync(Customer customer, CancellationToken cancellationToken);
        Task<Customer> UpdateAsync(Customer entity, CancellationToken cancellationToken);
        Task<Customer?> GetIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Customer>?> GetAll(CancellationToken cancellationToken);
    }
}


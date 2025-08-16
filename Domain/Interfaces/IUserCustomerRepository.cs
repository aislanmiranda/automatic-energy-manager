using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserCustomerRepository
{
    Task<UserCustomer> InsertAsync(UserCustomer usercustomer);
}
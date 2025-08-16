using Application.DTOs;

namespace Application.Interfaces;

public interface ICustomerApplication
{
    Task<Result<CreateCustomerResponse>> StartRegistrationCustomerAsync(CreateCustomerRequest customer, CancellationToken cancellationToken);
    Task<Result<UpdateCustomerResponse>> UpdateRegistrationCustomerAsync(UpdateCustomerRequest customer, CancellationToken cancellationToken);
    Task<Result<List<CustomersResponse>>> GetAll(CancellationToken cancellationToken);
}
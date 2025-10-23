using System.Security.Claims;
using Application.Interfaces;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Application.Services;

public class CustomerApplication : ICustomerApplication
{
    private readonly IUserRepository _userRepository;
    private readonly IUserCustomerRepository _userCustomerRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerApplication(IUserRepository userRepository,
        IUserCustomerRepository userCustomerRepository,
        ICustomerRepository customerRepository,
        ITaskRepository taskRepository,
        IHangFireApplication hangRepository,
        IHttpContextAccessor httpContextAccessor,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _userCustomerRepository = userCustomerRepository;
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<Result<CreateCustomerResponse>> StartRegistrationCustomerAsync(CreateCustomerRequest customer, CancellationToken cancellationToken)
    {
        try
        {
            var _user = _mapper.Map<User>(customer);
            var UserGuid = await _userRepository.InsertAsync(_user);

            var _customer = _mapper.Map<Customer>(customer);
            var CustomerGuid = await _customerRepository.InsertAsync(_customer, cancellationToken);

            await _userCustomerRepository.InsertAsync(new UserCustomer(UserGuid, CustomerGuid));
            return Result<CreateCustomerResponse>.Create(new CreateCustomerResponse { Success = true });
        }
        catch (Exception)
        {
            return Result<CreateCustomerResponse>.Fail("Erro ao cadastrar cliente");
        }
    }

    public async Task<Result<UpdateCustomerResponse>> UpdateRegistrationCustomerAsync(UpdateCustomerRequest customer, CancellationToken cancellationToken)
    {
        try
        {
            if(!ValidaStatusLiberado(customer))
                return Result<UpdateCustomerResponse>.Fail("Erro ao atualizar cliente");

            var existingEntity = await _customerRepository.GetIdAsync(customer.Id, cancellationToken);

            await _userRepository.UpdateStusAsync(existingEntity!.UserCustomer!.User.Id, cancellationToken);

            _mapper.Map(customer, existingEntity);

            var customerUpdated = await _customerRepository.UpdateAsync(existingEntity!, cancellationToken);

            var customerResponse = _mapper.Map<UpdateCustomerResponse>(customerUpdated);

            return Result<UpdateCustomerResponse>.Ok(customerResponse);
        }
        catch (Exception ex)
        {
            return Result<UpdateCustomerResponse>.Fail("Erro ao atualizar cliente");
        }
    }

    private bool ValidaStatusLiberado(UpdateCustomerRequest customer)
        =>  (customer.ZipCode!.Length > 0 && customer.Address!.Length > 0
                && customer.State!.Length == 2 && customer.Neighborhood!.Length > 0
                && customer.City!.Length > 0);

    public async Task<Result<List<CustomersResponse>>> GetAll(CancellationToken cancellationToken)
    {
        try
        {
            var customers = await _customerRepository.GetAll(cancellationToken);

            var responses = _mapper.Map<List<CustomersResponse>>(customers);

            return Result<List<CustomersResponse>>.Ok(responses);
        }
        catch (Exception)
        {
            return Result<List<CustomersResponse>>.Fail("Erro ao carregar clientes");
        }
    }
}
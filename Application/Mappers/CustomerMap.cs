using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
	public class CustomerMap : Profile
	{
		public CustomerMap()
		{
            CreateMap<CreateCustomerRequest, Customer>();
            CreateMap<Customer, CustomersResponse>()
                .ForMember(dest => dest.Status, src
                    => src.MapFrom(src => DefinitionStatus(src.UserCustomer!.User.Status)));

            CreateMap<UpdateCustomerRequest, Customer>();
            CreateMap<Customer, UpdateCustomerResponse>()
                .ForMember(dest => dest.Status, src
                    => src.MapFrom(src => DefinitionStatus(src.UserCustomer!.User.Status)));

        }

        private string DefinitionStatus(int status)
            => status switch
                {
                    0 => "Cliente Inativo",
                    1 => "Cliente Ativo",
                    2 => "Aguardando Configuração",
                    _ => "Status Indefinido",
                };
        
	}
}


using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
	public class UserMap : Profile
	{
		public UserMap()
		{
            CreateMap<CreateCustomerRequest, User>();
        }
	}
}


using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
	public class EquipamentMap : Profile
	{
		public EquipamentMap()
		{
            CreateMap<EquipamentCreateRequest, Equipament>();
            CreateMap<EquipamentUpdateRequest, Equipament>();
            CreateMap<Equipament, EquipamentResponse>();
        }
	}
}


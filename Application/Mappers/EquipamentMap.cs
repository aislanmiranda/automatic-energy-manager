using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
	public class EquipamentMap : Profile
	{
		public EquipamentMap()
		{
            CreateMap<EquipamentCreateRequest, Equipament>()
                .ForMember(dest => dest.OnOff, src => src.MapFrom(src => 0))
                .ForMember(dest => dest.Active, src => src.MapFrom(src => 1));

            CreateMap<EquipamentUpdateRequest, Equipament>();
            CreateMap<UpdateStateEquipamentRequest, Equipament>()
                .ReverseMap();
            CreateMap<EquipamentDeleteRequest, Equipament>();

            CreateMap<Equipament, EquipamentResponse>()
                .ForMember(dest => dest.OnOff, src => src.MapFrom(src => src.OnOff));
        }
	}
}


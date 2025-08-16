using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
	public class TaskMap : Profile
	{
		public TaskMap()
		{
			CreateMap<TaskRequest, ScheduleTask>();
            CreateMap<ScheduleTask, TaskResponse>();
            CreateMap<ScheduleTask, TaskEquipamentResponse>();
            CreateMap<ScheduleTask, SendFreezerOnOffRequest>();
        }
	}
}


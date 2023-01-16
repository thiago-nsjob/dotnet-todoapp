
using ThiagoToDo.Services.DTOs;
using AutoMapper;
using ThiagoToDo.Api.Contracts.Requests;

namespace ThiagoToDo.Api.Mapping
{
    public static class ApiMapperConfiguration
    {
        public static void AddApiProfiler(this IMapperConfigurationExpression cfg)
        {
             cfg.AddProfile<ToDoMappingProfile>();
        }
    }

    public class ToDoMappingProfile : Profile
    {

        public ToDoMappingProfile()
        {
            CreateMap<ToDo, ToDoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ToDoItem, opt => opt.MapFrom(src => src.Item));
        }

    }

}
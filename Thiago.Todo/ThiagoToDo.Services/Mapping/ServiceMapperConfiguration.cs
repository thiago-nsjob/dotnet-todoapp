using ThiagoToDo.DataAccessLayer.Entities;
using ThiagoToDo.Services.DTOs;
using AutoMapper;

namespace ThiagoToDo.Services.Mapping
{
    public static class ServiceMapperConfiguration
    {
        public static void AddServiceProfiler(this IMapperConfigurationExpression cfg)
        {
            cfg.AddProfile<ToDoMappingProfile>();
        }
    }
    
    public class ToDoMappingProfile : Profile
    {
        
        public ToDoMappingProfile()
        {
            CreateMap<ToDo, ToDoDTO>();
        }
    }
}

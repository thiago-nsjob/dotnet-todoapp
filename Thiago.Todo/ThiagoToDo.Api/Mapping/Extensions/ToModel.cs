
using AutoMapper;
using ThiagoToDo.Api.Contracts;
using ThiagoToDo.Services.DTOs;

namespace ThiagoToDo.Api.Mapping
{ 
    public static class MappingExtensions
    {

        public static ToDoDTO ToDTO(this ToDo model) =>
             Mapper.Map<ToDoDTO>(model);

        public static ToDo ToModel(this ToDoDTO dto) =>
             Mapper.Map<ToDo>(dto);

    }
}

  
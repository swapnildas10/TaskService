using AutoMapper;
using TaskService.Dtos;
using TaskService.Models;

namespace TaskService.Profiles
{
    public class TasksProfile : Profile
    {
        public TasksProfile()
        {
            CreateMap<TaskItem, TaskReadDto>();

            CreateMap<TaskCreateDto, TaskItem>();
            CreateMap<TaskUpdateDto, TaskItem>();

        }
    }
}
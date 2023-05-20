using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskService.Data;
using TaskService.Dtos;
using TaskService.Models;

namespace TaskService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskRepository _repository;
    private readonly IMapper _mapper;

    public TaskController(ITaskRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TaskReadDto>> GetTasks()
    {
        var taskItems = _repository.GetTasks();
        return Ok(_mapper.Map<IEnumerable<TaskReadDto>>(taskItems));
    }


    [HttpGet("{Id}", Name="GetTask")]
    public ActionResult<TaskReadDto> GetTask(int Id)
    {
        var taskItem = _repository.GetTask(Id);
        if (taskItem != null)
        {
            return Ok(_mapper.Map<TaskReadDto>(taskItem));
        }
        return NotFound();
    }

    [HttpPost]
    public ActionResult<TaskItem> CreateTask(TaskCreateDto taskCreateDto)
    {
        var taskItem = _mapper.Map<TaskItem>(taskCreateDto);
        _repository.AddTask(taskItem);
        var taskReadDto = _mapper.Map<TaskReadDto>(taskItem);
        return CreatedAtRoute(nameof(GetTask), new { Id = taskItem.Id }, taskReadDto);
    }

    [HttpPut("{Id}", Name="UpdateTask")]
    public ActionResult<TaskItem> UpdateTask(int Id, TaskUpdateDto taskUpdateDto)
    {
        var taskItem = _mapper.Map<TaskItem>(taskUpdateDto);
        _repository.UpdateTask(taskItem);
        
        var taskReadDto = _repository.GetTask(taskItem.Id);
        return Ok();
    }

    [HttpDelete("{Id}")]
    public ActionResult<TaskItem> DeleteTask(int Id)
    {
        var taskItem = _repository.GetTask(Id);
        if (taskItem == null)
        {
            return NotFound();
        }

        try
        {
            _repository.DeleteTask(taskItem);
        }
        catch (System.Exception ex)
        {

            throw ex;
        }


        return NoContent();
    }
}

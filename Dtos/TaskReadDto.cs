using System.ComponentModel.DataAnnotations;

namespace TaskService.Dtos
{
    public class TaskReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Priority { get; set; }

        public Status Status { get; set; }
    }
}
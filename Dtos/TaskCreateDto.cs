using System.ComponentModel.DataAnnotations;

namespace TaskService.Dtos
{
    public class TaskCreateDto
    {
        [Required]
        public string Name { get; set; } = String.Empty;

        [Required]
        [Range(int.MinValue,int.MaxValue)]
        public int Priority { get; set; }
        

    }
}
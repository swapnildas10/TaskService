using System.ComponentModel.DataAnnotations;

namespace TaskService.Dtos
{
    public class TaskUpdateDto
    {

        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;

        [Required]
        [Range(int.MinValue,int.MaxValue)]
        public int Priority { get; set; }

        [Required]
        public Status Status { get; set; }

    }
}
using System.ComponentModel.DataAnnotations;

namespace TaskService.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = String.Empty;

        [Required]
        [Range(int.MinValue,int.MaxValue)]
        public int Priority { get; set; }

        public Status Status { get; set; }
    }
}




using TaskService.Models;

namespace TaskService.Data
{
    public interface ITaskRepository
    {
        IEnumerable<TaskItem> GetTasks();

        TaskItem GetTask(int id);

        void AddTask(TaskItem task);

        void DeleteTask(TaskItem task);

        void UpdateTask(TaskItem task);
    }
}
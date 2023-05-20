using TaskService.Models;

namespace TaskService.Data
{
    public class TaskRepository : ITaskRepository
    {

        private List<TaskItem> tasks = new List<TaskItem>();

        public void AddTask(TaskItem task)
        {
            if (task == null)
            {
                // what is nameof used here for
                throw new ArgumentNullException(nameof(task));
            }

            if (IsNamePresent(task.Name))
            {
                throw new Exception("Task name must be unique");
            }
            task.Id = tasks.Count + 1;
            task.Status = Status.NotStarted;
            tasks.Add(task);
        }

        public void DeleteTask(TaskItem task)
        {
            var taskItem = tasks.FirstOrDefault(t => t.Id == task.Id);

            if (taskItem == null)
            {
                throw new KeyNotFoundException();
            }

            if (taskItem.Status != Status.Completed)
            {
                throw new Exception("Only completed tasks can be deleted.");
            }

            tasks.Remove(task);
        }

        public TaskItem GetTask(int id)
        {
            TaskItem taskItem = tasks.FirstOrDefault(t => t.Id == id);
            if (taskItem == null)
            {
                throw new KeyNotFoundException(nameof(taskItem));
            }
            return taskItem;
        }

        public IEnumerable<TaskItem> GetTasks()
        {
            return tasks;
        }

        public void UpdateTask(TaskItem task)
        {
            TaskItem taskItem = tasks.FirstOrDefault(t => t.Id == task.Id);

            if (taskItem == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            if (taskItem.Name != task.Name)
            {
                throw new Exception("Name cannot be different");
            }

            tasks[taskItem.Id - 1].Name = task.Name;
            tasks[taskItem.Id - 1].Status = task.Status;
            tasks[taskItem.Id - 1].Priority = task.Priority;
        }


        private bool IsNamePresent(string name)
        {
            return tasks.Any(t => t.Name == name);
        }
    }
}
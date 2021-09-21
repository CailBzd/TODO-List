
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TODO.Domain.Models;

namespace TODO.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskItem> AddTaskAsync(TaskItem task);
        Task<ICollection<TaskItem>> GetAllTasksAsync();
        Task<ICollection<TaskItem>> GetTasksByUser(string iduser);
    }
}

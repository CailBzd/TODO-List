using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Domain.Interfaces;
using TODO.Domain.Models;
using TODO.Infra.Contexts;

namespace TODO.Infra.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TODOContext _context;

        public TaskRepository(TODOContext context)
        {
            this._context = context;
        }

        //AddTask
        public async Task<TaskItem> AddTaskAsync(TaskItem task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        //GetAllTasks
        public async Task<ICollection<TaskItem>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        //GetTaskByUser
        public async Task<ICollection<TaskItem>> GetTasksByUser(string iduser)
        {
            return await _context.Tasks.Where(task => task.UserID.ToString() == iduser.ToString()).ToListAsync();
        }


    }
}

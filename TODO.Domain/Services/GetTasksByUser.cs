using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Domain.Interfaces;
using TODO.Domain.Models;

namespace TODO.Domain.Services
{    
    public class GetTasksByUser
    {
        private readonly ITaskRepository _taskRepository;

        public GetTasksByUser(ITaskRepository taskRepository)
        {
            this._taskRepository = taskRepository;
        }

        public async Task<ICollection<TaskItem>> GetTasks(string userId)
        {
            return await _taskRepository.GetTasksByUser(userId);
        }
    }
}

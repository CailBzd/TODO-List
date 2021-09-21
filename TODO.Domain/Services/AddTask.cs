using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Domain.Interfaces;
using TODO.Domain.Models;

namespace TODO.Domain.Services
{
    public class AddTask
    {
        private readonly IUserRepository _userRepository;
        private readonly ITaskRepository _taskRepository;

        public AddTask(IUserRepository userRepository,ITaskRepository taskRepository)
        {
            this._userRepository = userRepository;
            this._taskRepository = taskRepository;
        }

        public async Task<TaskItem> AddAsync(string userId,string libelle, bool completed)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            var newTask = new TaskItem
            {
                User = user,
                Libelle = libelle,
                Completed = completed,
                DateCreated = DateTime.Now
            };

            return await _taskRepository.AddTaskAsync(newTask);

        }
    }
}

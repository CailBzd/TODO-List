using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO.Domain.Models
{
    public class User
    {
        public User()
        {
            Tasks = new List<TaskItem>();
        }
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<TaskItem> Tasks { get; set; }

    }
}

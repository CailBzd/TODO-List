using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO.Domain.Models
{
    public class TaskItem
    {
        public TaskItem()
        {

        }

        public Guid Id { get; set; }

        public string Libelle { get; set; }

        public bool Completed { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateCompleted { get; set; }

        public User User { get; set; }
        public Guid UserID { get; set; }

    }
}

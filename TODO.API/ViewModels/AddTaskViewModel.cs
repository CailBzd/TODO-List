using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TODO.API.ViewModels
{
    public class AddTaskViewModel
    {
        [Required]
        public string libelle { get; set; }
        public bool completed { get; set; }
        
    }
}

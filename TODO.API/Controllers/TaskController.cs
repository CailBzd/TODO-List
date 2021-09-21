using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using TODO.API.ViewModels;
using TODO.Domain.Services;

namespace TODO.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TaskController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Index([FromServices] GetTasksByUser hdr)
        {
            Console.WriteLine("--> TaskController : Index");

            var clmIdentity = User.Identity as ClaimsIdentity;
            var userId = clmIdentity.Claims.Where(claim => claim.Type == "id").FirstOrDefault().Value;
            Console.WriteLine(userId);
            var tasks = await hdr.GetTasks(userId.ToString());

            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTaskViewModel model, [FromServices] AddTask hdr)
        {
            Console.WriteLine("--> TaskController : Add");

            var identity = User.Identity as ClaimsIdentity;
            var userId = identity.Claims.Where(claim => claim.Type == "id").FirstOrDefault().Value;
            var newTask = await hdr.AddAsync(userId.ToString(), model.libelle, model.completed);

            return Ok(new
            {
                id = newTask.Id,
                libelle = newTask.Libelle,
                completed = newTask.Completed,
                dateCreated = System.DateTime.Now
            });
        }
    }
}

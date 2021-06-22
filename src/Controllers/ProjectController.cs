using Microsoft.AspNetCore.Mvc;
using Manawork.DTOs.Projects;
using Manawork.Models.Project;
using Manawork.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Manawork.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        IProjectService _projectService;
        IUserService _userService;

        public ProjectController(IProjectService projectService, IUserService userService)
        {
            _projectService = projectService;
            _userService = userService;
        }

        [Route("/Project/Kanban/{id}")]
        public IActionResult Kanban(int id)
        {
            return View(_projectService.GetProjectById(id));
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(AddProjectViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Project project = new Project()
            {
                Title = model.Title,
                Description = model.Description,
                CreateDate = System.DateTime.Now,
                UserId = _userService.GetUserIdByEmail(User.Identity.Name),
                IsDelete = false
            };

            _projectService.AddProject(project);

            return Redirect("/");
        }
    }
}

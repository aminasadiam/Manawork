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
            ViewData["TodoCarts"] = _projectService.GetTodoCartByProjectId(id);
            ViewData["InProcessCarts"] = _projectService.GetInProcessByProjectId(id);
            ViewData["DoneCarts"] = _projectService.GetDoneCartByProjectId(id);
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

        public IActionResult AddCart(int id)
        {
            ViewBag.ProjectId = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddCart(AddCartViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Cart cart = new Cart(){
                Name = model.Name,
                ProjectId = model.ProjectId,
                IsDelete = false,
                StatusNumber = 1
            };

            _projectService.AddCart(cart);

            return Redirect($"/Project/Kanban/{model.ProjectId}");
        }

        public IActionResult GoToNextLevel(int id)
        {
            var cart = _projectService.GetCartById(id);
            if (cart.StatusNumber == 2)
            {
                cart.StatusNumber = 3;
            }
            if (cart.StatusNumber == 1)
            {
                cart.StatusNumber = 2;
            }

            _projectService.UpdateCart(cart);

            return Redirect($"/Project/Kanban/{cart.ProjectId}");
        }

        public IActionResult DeleteCart(int id)
        {
            var cart = _projectService.GetCartById(id);
            cart.IsDelete = true;
            _projectService.UpdateCart(cart);
            return Redirect($"/Project/Kanban/{cart.ProjectId}");
        }

        public IActionResult DeleteProject(int id)
        {
            var project = _projectService.GetProjectById(id);
            project.IsDelete = true;
            _projectService.UpdateProject(project);
            return Redirect("/");
        }
    }
}

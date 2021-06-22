using Manawork.Models.Project;
using Manawork.Services.Interfaces;
using Manawork.Contxet;
using System.Linq;
using Manawork.DTOs.Projects;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Manawork.Services
{
    public class ProjectService : IProjectService
    {
        ManaworkContext _context;

        public ProjectService(ManaworkContext context)
        {
            _context = context;
        }

        public void AddProject(Project model)
        {
            _context.Projects.Add(model);
            _context.SaveChanges();
        }

        public Project GetProjectById(int id)
        {
            return _context.Projects.Find(id);
        }

        public List<ShowProjectsViewModel> GetProjects()
        {
            IQueryable<Project> result = _context.Projects.OrderByDescending(p => p.CreateDate);

            return result.Include(p => p.User).Select(p => new ShowProjectsViewModel()
            {
                Title = p.Title,
                Descrioption = p.Description,
                Creator = p.User.Username,
                ProjectId = p.ProjectId
            }).ToList();
        }
    }
}
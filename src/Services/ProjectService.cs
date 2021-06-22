using Manawork.Models.Project;
using Manawork.Services.Interfaces;
using Manawork.Contxet;
using System.Linq;
using Manawork.DTOs.Projects;

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
    }
}
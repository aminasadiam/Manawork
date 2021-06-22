using Manawork.Models.Project;
using Manawork.DTOs.Projects;
using System.Collections.Generic;

namespace Manawork.Services.Interfaces
{
    public interface IProjectService
    {
        void AddProject(Project model);
        List<ShowProjectsViewModel> GetProjects();
        Project GetProjectById(int id);
    }
}
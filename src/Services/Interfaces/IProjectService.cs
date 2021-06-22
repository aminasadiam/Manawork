using Manawork.Models.Project;
using Manawork.DTOs.Projects;

namespace Manawork.Services.Interfaces
{
    public interface IProjectService
    {
        void AddProject(Project model);
    }
}
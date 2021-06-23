using Manawork.Models.Project;
using Manawork.Services.Interfaces;
using Manawork.Contxet;
using System.Linq;
using Manawork.DTOs.Projects;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;

namespace Manawork.Services
{
    public class ProjectService : IProjectService
    {
        ManaworkContext _context;

        public ProjectService(ManaworkContext context)
        {
            _context = context;
        }

        public void AddCart(Cart model)
        {
            _context.Carts.Add(model);
            _context.SaveChanges();
        }

        public void AddProject(Project model)
        {
            _context.Projects.Add(model);
            _context.SaveChanges();
        }

        public Cart GetCartById(int id)
        {
            return _context.Carts.SingleOrDefault(c => c.CartId == id);
        }

        public List<Cart> GetDoneCartByProjectId(int projectId)
        {
            return  _context.Carts.Where(c => c.ProjectId == projectId && c.StatusNumber == 3).ToList();
        }

        public List<Cart> GetInProcessByProjectId(int projectId)
        {
            return  _context.Carts.Where(c => c.ProjectId == projectId && c.StatusNumber == 2).ToList();
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

        public List<Cart> GetTodoCartByProjectId(int projectId)
        {
            return  _context.Carts.Where(c => c.ProjectId == projectId && c.StatusNumber == 1).ToList();
        }

        public void UpdateCart(Cart cart)
        {
            _context.Carts.Update(cart);
            _context.SaveChanges();
        }

        public void UpdateProject(Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
        }
    }
}
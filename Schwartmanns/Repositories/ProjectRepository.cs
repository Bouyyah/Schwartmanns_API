using Microsoft.EntityFrameworkCore;
using Schwartmanns.Data;
using Schwartmanns.Interfaces;
using Schwartmanns.Models;

namespace Schwartmanns.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _context;

        public ProjectRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects.OrderBy(p=>p.Id).ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Project> CreateProjectAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task UpdateProjectAsync(Project project)
        {
            _context.Entry(project).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }

        public Dictionary<string, int> GetProjectDistributionByClient()
        {
            var result = _context.Clients
                .Include(c => c.Projects)
                .ToDictionary(client => client.Name, client => client.Projects.Count);

            return result;
        }

        public Dictionary<string, int> GetProjectDistributionByUser()
        {
            var result = _context.Users
                .Include(u => u.Projects)
                .ToDictionary(user => user.Name, user => user.Projects.Count);

            return result;
        }
    }
}

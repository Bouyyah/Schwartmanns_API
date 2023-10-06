using Microsoft.EntityFrameworkCore;
using Schwartmanns.Data;
using Schwartmanns.Interfaces;
using Schwartmanns.Models;

namespace Schwartmanns.Repositories
{
    public class ProjectJobsRepository : IProjectJobsRepository
    {
        private readonly DataContext _context;

        public ProjectJobsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Job>> GetJobsByProjectIdAsync(int projectId)
        {
            return await _context.Jobs.Where(j => j.ProjectId == projectId).ToListAsync();
        }
    }
}

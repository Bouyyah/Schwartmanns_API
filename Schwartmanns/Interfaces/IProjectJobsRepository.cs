using Schwartmanns.Models;

namespace Schwartmanns.Interfaces
{
    public interface IProjectJobsRepository
    {
        Task<IEnumerable<Job>> GetJobsByProjectIdAsync(int projectId);
    }
}

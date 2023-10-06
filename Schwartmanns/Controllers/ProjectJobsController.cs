using Microsoft.AspNetCore.Mvc;
using Schwartmanns.Interfaces;
using Schwartmanns.Models;

namespace Schwartmanns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectJobsController : ControllerBase
    {
        private readonly IProjectJobsRepository _projectJobsRepository;

        public ProjectJobsController(IProjectJobsRepository projectJobsRepository)
        {
            _projectJobsRepository = projectJobsRepository;
        }

        [HttpGet("projectJobs/{projectId}")]
        public async Task<ActionResult<IEnumerable<Job>>> GetJobsByProjectId(int projectId)
        {
            var jobs = await _projectJobsRepository.GetJobsByProjectIdAsync(projectId);
            return Ok(jobs);
        }
    }
}

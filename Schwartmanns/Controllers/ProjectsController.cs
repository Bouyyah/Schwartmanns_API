using Microsoft.AspNetCore.Mvc;
using Schwartmanns.Interfaces;
using Schwartmanns.Models;

namespace Schwartmanns.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectsController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            var projects = await _projectRepository.GetAllProjectsAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var project = await _projectRepository.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project project)
        {
            await _projectRepository.CreateProjectAsync(project);
            return CreatedAtAction("GetProject", new { id = project.Id }, project);
        }

        

        [HttpGet("projectDistributionByClient")]
        public ActionResult<Dictionary<string, int>> GetProjectDistributionByClient()
        {
            var projectDistribution = _projectRepository.GetProjectDistributionByClient();
            return Ok(projectDistribution);
        }

        [HttpGet("projectDistributionByUser")]
        public ActionResult<Dictionary<string, int>> GetProjectDistributionByUser()
        {
            var projectDistribution = _projectRepository.GetProjectDistributionByUser();
            return Ok(projectDistribution);
        }
    }
}

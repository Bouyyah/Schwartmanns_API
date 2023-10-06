using Microsoft.AspNetCore.Mvc;
using Schwartmanns.Interfaces;
using Schwartmanns.Models;
using Schwartmanns.Repositories;

namespace Schwartmanns.Controllers
{
    [Route("api/")]
    [ApiController]
    public class JobSheetsController : ControllerBase
    {
        private readonly IJobSheetsRepository _jobSheetsRepository;

        public JobSheetsController(IJobSheetsRepository jobSheetsRepository)
        {
            _jobSheetsRepository = jobSheetsRepository;
        }

        [HttpGet("jobSheets/{projectId}/{jobId}")]
        public async Task<ActionResult<IEnumerable<Sheet>>> GetSheetsByJobAndProjectId(int projectId, int jobId)
        {
            var sheets = await _jobSheetsRepository.GetSheetsByJobAndProjectIdAsync(projectId, jobId);
            return Ok(sheets);
        }

        [HttpGet("jobSheet/{projectId}/{jobId}/{sheetId}")]
        public async Task<ActionResult<Sheet>> GetSheetById(int projectId, int jobId, int sheetId)
        {
            var sheet = await _jobSheetsRepository.GetSheetByIdAsync(projectId, jobId, sheetId);
            if (sheet == null)
            {
                return NotFound();
            }
            return Ok(sheet);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Schwartmanns.Data;
using Schwartmanns.Interfaces;
using Schwartmanns.Models;

namespace Schwartmanns.Repositories
{
    public class JobSheetsRepository : IJobSheetsRepository
    {
        private readonly DataContext _context;

        public JobSheetsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sheet>> GetSheetsByJobAndProjectIdAsync(int projectId, int jobId)
        {
            return await _context.Sheets
                .Where(sheet => sheet.JobId == jobId && sheet.Job.ProjectId == projectId)
                .ToListAsync();
        }

        public async Task<Sheet?> GetSheetByIdAsync(int projectId, int jobId, int sheetId)
        {
            return await _context.Sheets
                .FirstOrDefaultAsync(sheet =>
                    sheet.Id == sheetId &&
                    sheet.JobId == jobId &&
                    sheet.Job.ProjectId == projectId);
        }
    }
}

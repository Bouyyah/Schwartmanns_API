using Schwartmanns.Models;

namespace Schwartmanns.Interfaces
{
    public interface IJobSheetsRepository
    {
        Task<IEnumerable<Sheet>> GetSheetsByJobAndProjectIdAsync(int projectId, int jobId);

        Task<Sheet?> GetSheetByIdAsync(int projectId, int jobId, int sheetId);
    }
}

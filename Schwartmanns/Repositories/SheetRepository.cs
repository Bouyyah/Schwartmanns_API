using Schwartmanns.Data;
using Schwartmanns.Interfaces;

namespace Schwartmanns.Repositories
{
    public class SheetRepository : ISheetRepository
    {
        private readonly DataContext _context; 

        public SheetRepository(DataContext context)
        {
            _context = context;
        }

        public Dictionary<int, int> GetTotalCircles()
        {
            var result = _context.Sheets
                .Select(sheet => new
                {
                    SheetId = sheet.Id,
                    TotalCircles = sheet.Circles.Count
                    
                })
                .ToDictionary(x => x.SheetId, x => x.TotalCircles );

            return result;
        }

        public Dictionary<int, int> GetTotalLines()
        {
            var result = _context.Sheets
                .Select(sheet => new
                {
                    SheetId = sheet.Id,
                    TotalLines = sheet.Lines.Count

                })
                .ToDictionary(x => x.SheetId, x => x.TotalLines);

            return result;
        }
    }

}

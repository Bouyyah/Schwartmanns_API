using Microsoft.AspNetCore.Mvc;
using Schwartmanns.Interfaces;

namespace Schwartmanns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SheetController : ControllerBase
    {
        private readonly ISheetRepository _sheetRepository;

        public SheetController(ISheetRepository sheetRepository)
        {
            _sheetRepository = sheetRepository;
        }

        [HttpGet("totalCircles")]
        public ActionResult<Dictionary<int, int>> GetTotalCircles()
        {
            var circlePolylineStats = _sheetRepository.GetTotalCircles();
            return Ok(circlePolylineStats);
        }

        [HttpGet("totalLines")]
        public ActionResult<Dictionary<int, int>> GetTotalLines()
        {
            var circlePolylineStats = _sheetRepository.GetTotalLines();
            return Ok(circlePolylineStats);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Schwartmanns.Interfaces;
using Schwartmanns.Models;

namespace Schwartmanns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CircleController : ControllerBase
    {
        private readonly ICircleRepository _circleRepository;

        public CircleController(ICircleRepository circleRepository)
        {
            _circleRepository = circleRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<CircleProperties> GetCircleProperties(int id)
        {
            try
            {
                var circleProperties = _circleRepository.CalculateCircleProperties(id);

                return Ok(circleProperties);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while calculating circle properties.");
            }
        }
    }
}

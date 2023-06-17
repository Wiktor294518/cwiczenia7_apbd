using Cw7.DTOs;
using Cw7.Models;
using Cw7.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cw7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly Cw7Context _context;
        private readonly ITripsService _service;
        public TripsController(Cw7Context context, ITripsService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }
    }
}

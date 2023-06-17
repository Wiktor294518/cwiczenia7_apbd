using Cw7.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cw7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {

        private readonly Cw7Context _context;
        public CountriesController(Cw7Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(
                    await _context.Countries
                    .Select(e => new CountryResponse { Name = e.Name})
                    .ToListAsync()
                );
        }

        [HttpPost]
        public async Task<IActionResult> Add(CountryRequest data)
        {
            if (await _context.Countries.AnyAsync(e => e.IdCountry == data.IdCountry)) return Conflict();
            await _context.Countries.AddAsync(new Country
            {
                IdCountry = data.IdCountry,
                Name = data.Name,
            });
            await _context.SaveChangesAsync();
            return Created("", "");
        }

        [HttpPut("{index}")]
        public async Task<IActionResult> Update(int index, CountryUpdateRequest data)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(e => e.IdCountry == index);
            if(country == null) return NotFound();

            country.Name = data.Name;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{index}")]
        public async Task<IActionResult> Remove(int index)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(e => e.IdCountry == index);
            if (country == null) return NotFound();

            _context.Countries.Remove(country);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }

    public class CountryResponse
    {
        public string Name { get; set; }
    }

    public class CountryRequest
    {
        public int IdCountry { get; set; }
        public string Name { get; set; }
    }

    public class CountryUpdateRequest
    { 
        public string Name { get; set; }
    }
}

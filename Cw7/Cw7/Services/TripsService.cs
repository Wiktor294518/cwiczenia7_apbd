using Cw7.DTOs;
using Cw7.Models;
using Microsoft.EntityFrameworkCore;

namespace Cw7.Services
{

    public interface ITripsService
    {
        public Task<List<TripsGetAllResponse>> GetAll();
    }
    public class TripsService : ITripsService
    {
        private readonly Cw7Context _context;
        public TripsService(Cw7Context context)
        {
            _context = context;
        }
        public async Task<List<TripsGetAllResponse>> GetAll()
        {
            return await _context.Trips.Select(e => new TripsGetAllResponse
            {
                Name = e.Name,
                Description = e.Description,
                DateFrom = e.DateFrom,
                DateTo = e.DateTo,
                MaxPeople = e.MaxPeople,
                Countries = e.IdCountries.Select(a => new TripsGetAllResponseCountry
                {
                    Name = a.Name
                }).ToList(),
                Clients = e.ClientTrips.Select(a => new TripsGetAllResponseClient
                {
                    FirstName = a.IdClientNavigation.FirstName,
                    LastName = a.IdClientNavigation.LastName,
                }).ToList()
            }).ToListAsync();
        }
    }
}

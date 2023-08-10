using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class CityRepository : ICityRepository
    {
        protected readonly ITrybeHotelContext _context;
        public CityRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 2. Desenvolva o endpoint GET /city
        public IEnumerable<CityDto> GetCities()
        {
            return _context.Cities.Select(city => new CityDto
            {
                CityId = city.CityId,
                Name = city.Name
            });
        }

        // 3. Desenvolva o endpoint POST /city
        public CityDto AddCity(City city)
        {
            var newCity = _context.Cities.Add(city);
            return new CityDto
            {
                CityId = newCity.Entity.CityId,
                Name = newCity.Entity.Name
            };
            _context.SaveChanges();
        }

    }
}
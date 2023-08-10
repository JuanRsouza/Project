using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class HotelRepository : IHotelRepository
    {
        protected readonly ITrybeHotelContext _context;
        public HotelRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 4. Desenvolva o endpoint GET /hotel
        public IEnumerable<HotelDto> GetHotels()
        {
            return _context.Hotels.Select(hotel => new HotelDto
            {
                HotelId = hotel.HotelId,
                Name = hotel.Name,
                Address = hotel.Address,
                CityId = hotel.CityId,
                CityName = hotel.City.Name
            }).ToList();
        }
        
        // 5. Desenvolva o endpoint POST /hotel
        public HotelDto AddHotel(Hotel hotel)
        {
            var newHotel = _context.Hotels.Add(hotel);
            return new HotelDto
            {
                HotelId = newHotel.Entity.HotelId,
                Name = newHotel.Entity.Name,
                Address = newHotel.Entity.Address,
                CityId = newHotel.Entity.CityId,
                CityName = _context.Cities.Find(newHotel.Entity.CityId).Name
            };
            _context.SaveChanges();
        }
    }
}
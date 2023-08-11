using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class RoomRepository : IRoomRepository
    {
        protected readonly ITrybeHotelContext _context;
        public RoomRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 6. Desenvolva o endpoint GET /room/:hotelId
        public IEnumerable<RoomDto> GetRooms(int HotelId)
        {
            return _context.Rooms.Select(rooms => new RoomDto
            {
                RoomId = rooms.RoomId,
                Name = rooms.Name,
                Capacity = rooms.Capacity,
                Image = rooms.Image,
                Hotel = new HotelDto
                {
                    HotelId = rooms.Hotel.HotelId,
                    Name = rooms.Hotel.Name,
                    Address = rooms.Hotel.Address,
                    CityId = rooms.Hotel.CityId,
                    CityName = rooms.Hotel.City.Name
                }
            }).ToList();
        }

        // 7. Desenvolva o endpoint POST /room
        public RoomDto AddRoom(Room room)
        {
            var newRoom = _context.Rooms.Add(room);
            return new RoomDto
            {
                RoomId = newRoom.Entity.RoomId,
                Name = newRoom.Entity.Name,
                Capacity = newRoom.Entity.Capacity,
                Image = newRoom.Entity.Image,
                Hotel = _context.Hotels.Where(hotel => hotel.HotelId == newRoom.Entity.HotelId)
                    .Select(hotel => new HotelDto
                    {
                        HotelId = hotel.HotelId,
                        Name = hotel.Name,
                        Address = hotel.Address,
                        CityId = hotel.CityId,
                        CityName = hotel.City.Name                     
                    }).FirstOrDefault()

            };
            _context.SaveChanges();


        }

        // 8. Desenvolva o endpoint DELETE /room/:roomId
        public void DeleteRoom(int RoomId)
        {
            var findRoom = _context.Rooms.Find(RoomId);
            _context.Rooms.Remove(findRoom);
            _context.SaveChanges();
        }
    }
}
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
                Hotel = new HotelDto
                {
                    HotelId = newRoom.Entity.Hotel.HotelId,
                    Name = newRoom.Entity.Hotel.Name,
                    Address = newRoom.Entity.Hotel.Address,
                    CityId = newRoom.Entity.Hotel.CityId,
                    CityName = newRoom.Entity.Hotel.City.Name
                }
            };
            _context.SaveChanges();


        }

        // 8. Desenvolva o endpoint DELETE /room/:roomId
        public void DeleteRoom(int RoomId)
        {
            throw new NotImplementedException();
        }
    }
}
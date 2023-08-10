using Microsoft.EntityFrameworkCore;
using TrybeHotel.Models;

namespace TrybeHotel.Repository;
public class TrybeHotelContext : DbContext, ITrybeHotelContext
{

    public TrybeHotelContext(DbContextOptions<TrybeHotelContext> options) : base(options) { }
    public DbSet<City> Cities { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Room> Rooms { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"
            Server=localhost;
            Database=TrybeHotel;
            User=SA;
            Password=TrybeHotel12!;
            TrustServerCertificate=True
            "
        );
    }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Hotel>()
        .HasOne(hotel => hotel.City)
        .WithMany(city => city.Hotels)
        .HasForeignKey(hotel => hotel.CityId);

        mb.Entity<Room>()
        .HasOne(room => room.Hotel)
        .WithMany(hotel => hotel.Rooms)
        .HasForeignKey(room => room.HotelId);
    }
    public TrybeHotelContext() { }
}
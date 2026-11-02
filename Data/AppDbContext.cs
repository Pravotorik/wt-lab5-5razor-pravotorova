using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_pravotorova.Models;

namespace wt_lab8_8razor_postgresql_pravotorova.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Таблицы в базе данных
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<Guest> Guests => Set<Guest>();
    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<Amenity> Amenities => Set<Amenity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Настройка связей (Relationships)
        // Бронь связана с одним номером
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Room)
            .WithMany()
            .HasForeignKey(r => r.RoomId)
            .OnDelete(DeleteBehavior.Cascade);

        // Бронь связана с одним гостем
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Guest)
            .WithMany()
            .HasForeignKey(r => r.GuestId)
            .OnDelete(DeleteBehavior.Cascade);

        //  для номеров
        modelBuilder.Entity<Room>().HasData(
            new Room { Id = 1, Number = "101", Category = "Стандарт", Capacity = 2, PricePerNight = 3500, IsAvailable = true, Description = "Уютный номер", ImageUrl = "https://images.unsplash.com/photo-1611892440504-42a792e24d32?w=800" },
            new Room { Id = 2, Number = "102", Category = "Люкс", Capacity = 2, PricePerNight = 9000, IsAvailable = true, Description = "С джакузи", ImageUrl = "https://images.unsplash.com/photo-1582719508461-905c673771fd?w=800" },
            new Room { Id = 3, Number = "201", Category = "Комфорт", Capacity = 3, PricePerNight = 5200, IsAvailable = false, Description = "Семейный номер", ImageUrl = "https://images.unsplash.com/photo-1590490360182-c33d57733427?w=800" }
        );

        // Н для гостей
        modelBuilder.Entity<Guest>().HasData(
            new Guest { Id = 1, FullName = "Анна Смирнова", Email = "anna@mail.com", Phone = "+375 29 111-22-33", Country = "Беларусь", AvatarUrl = "https://i.pravatar.cc/150?img=47" },
            new Guest { Id = 2, FullName = "Иван Петров", Email = "ivan@mail.com", Phone = "+375 29 444-55-66", Country = "Россия", AvatarUrl = "https://i.pravatar.cc/150?img=12" },
            new Guest { Id = 3, FullName = "Мария Ковалёва", Email = "maria@mail.com", Phone = "+375 29 777-88-99", Country = "Польша", AvatarUrl = "https://i.pravatar.cc/150?img=32" }
        );
    }
}
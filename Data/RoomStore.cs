using wt_lab5_5razor_pravotorova.Models;

namespace wt_lab5_5razor_pravotorova.Data;

public static class RoomStore
{
    public static List<Room> Rooms { get; } = new()
    {
        new Room {
            Id = 1, Number = "101", Category = "Стандарт", Capacity = 2,
            PricePerNight = 3500, IsAvailable = true,
            ImageUrl = "https://images.unsplash.com/photo-1611892440504-42a792e24d32?w=800",
            Description = "Уютный номер с видом на сад."
        },
        new Room {
            Id = 2, Number = "102", Category = "Стандарт", Capacity = 2,
            PricePerNight = 3700, IsAvailable = true,
            ImageUrl = "https://images.unsplash.com/photo-1631049307264-da0ec9d70304?w=800",
            Description = "Светлый номер с панорамным окном."
        },
        new Room {
            Id = 3, Number = "201", Category = "Комфорт", Capacity = 2,
            PricePerNight = 5200, IsAvailable = true,
            ImageUrl = "https://images.unsplash.com/photo-1590490360182-c33d57733427?w=800",
            Description = "Просторный номер с рабочей зоной."
        },
        new Room {
            Id = 4, Number = "202", Category = "Комфорт", Capacity = 3,
            PricePerNight = 6100, IsAvailable = false,
            ImageUrl = "https://images.unsplash.com/photo-1566665797739-1674de7a421a?w=800",
            Description = "Семейный номер с дополнительным местом."
        },
        new Room {
            Id = 5, Number = "301", Category = "Люкс", Capacity = 3,
            PricePerNight = 8900, IsAvailable = true,
            ImageUrl = "https://images.unsplash.com/photo-1582719508461-905c673771fd?w=800",
            Description = "Люкс с гостиной зоной и джакузи."
        },
        new Room {
            Id = 6, Number = "401", Category = "Апартаменты", Capacity = 4,
            PricePerNight = 15000, IsAvailable = false,
            ImageUrl = "https://images.unsplash.com/photo-1591088398332-8a7791972843?w=800",
            Description = "Двухуровневые апартаменты с террасой."
        }
    };
}
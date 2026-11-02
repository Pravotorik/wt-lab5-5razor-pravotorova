namespace wt_lab8_8razor_postgresql_pravotorova.Models;

public class Reservation
{
    public int Id { get; set; }

    public int RoomId { get; set; }
    public Room? Room { get; set; }

    public int GuestId { get; set; }
    public Guest? Guest { get; set; }

    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public decimal TotalPrice { get; set; }
    public string Status { get; set; } = "Подтверждена";
}
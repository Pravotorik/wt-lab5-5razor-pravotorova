using System.ComponentModel.DataAnnotations;

namespace wt_lab8_8razor_postgresql_pravotorova.Models;

public class Room
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Укажите номер комнаты")]
    public string Number { get; set; } = "";

    [Required(ErrorMessage = "Укажите категорию")]
    public string Category { get; set; } = "";

    public int Capacity { get; set; }
    public decimal PricePerNight { get; set; }
    public bool IsAvailable { get; set; } = true;
    public string ImageUrl { get; set; } = "";
    public string Description { get; set; } = ""; // Добавлено для миграции
}
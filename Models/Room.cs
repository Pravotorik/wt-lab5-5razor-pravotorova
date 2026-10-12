using System.ComponentModel.DataAnnotations;

namespace wt_lab5_5razor_pravotorova.Models;

public class Room
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Укажите номер комнаты")]
    [StringLength(10)]
    public string Number { get; set; } = string.Empty;

    [Required(ErrorMessage = "Укажите категорию")]
    public string Category { get; set; } = string.Empty;

    [Range(1, 10, ErrorMessage = "Вместимость от 1 до 10")]
    public int Capacity { get; set; }

    [Range(0.01, 1000000, ErrorMessage = "Цена должна быть положительной")]
    public decimal PricePerNight { get; set; }

    public bool IsAvailable { get; set; } = true;
    public string ImageUrl { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
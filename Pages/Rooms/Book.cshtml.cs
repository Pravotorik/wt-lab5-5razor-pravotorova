using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_pravotorova.Data;
using wt_lab5_5razor_pravotorova.Models;

namespace wt_lab5_5razor_pravotorova.Pages.Rooms;

public class BookModel : PageModel
{
    public List<Room> AvailableRooms { get; set; } = new();
    public string? Message { get; set; }
    public bool Success { get; set; }

    public void OnGet()
    {
        AvailableRooms = RoomStore.Rooms.Where(r => r.IsAvailable).ToList();
    }

    public IActionResult OnPost(int selectedRoomId)
    {
        var room = RoomStore.Rooms.FirstOrDefault(r => r.Id == selectedRoomId);
        if (room == null || !room.IsAvailable)
        {
            AvailableRooms = RoomStore.Rooms.Where(r => r.IsAvailable).ToList();
            Message = "Этот номер уже занят или не найден.";
            Success = false;
            return Page();
        }

        // Бронирование = смена статуса, а НЕ создание нового номера
        room.IsAvailable = false;

        TempData["Success"] = $"Номер № {room.Number} успешно забронирован!";
        return RedirectToPage("./Index");
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_pravotorova.Data;
using wt_lab8_8razor_postgresql_pravotorova.Models;

namespace wt_lab8_8razor_postgresql_pravotorova.Pages.Rooms;

public class BookModel : PageModel
{
    private readonly AppDbContext _context;

    public BookModel(AppDbContext context)
    {
        _context = context;
    }

    public IList<Room> AvailableRooms { get; set; } = default!;

    [BindProperty]
    public int SelectedRoomId { get; set; }

    // --- ВОТ ЭТИ ДВЕ СТРОКИ НУЖНЫ ДЛЯ HTML ---
    public string? Message { get; set; }
    public bool Success { get; set; }
    // -----------------------------------------

    public async Task OnGetAsync()
    {
        AvailableRooms = await _context.Rooms
            .Where(r => r.IsAvailable)
            .ToListAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var room = await _context.Rooms.FindAsync(SelectedRoomId);

        if (room != null && room.IsAvailable)
        {
            room.IsAvailable = false;
            await _context.SaveChangesAsync();
            TempData["Success"] = $"Номер {room.Number} успешно забронирован!";
            return RedirectToPage("./Index");
        }
        else
        {
            Message = "Этот номер уже занят или не найден.";
            Success = false;
            AvailableRooms = await _context.Rooms.Where(r => r.IsAvailable).ToListAsync();
            return Page();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_pravotorova.Data;
using wt_lab5_5razor_pravotorova.Models;

namespace wt_lab5_5razor_pravotorova.Pages.Rooms;

public class EditModel : PageModel
{
    [BindProperty]
    public Room Room { get; set; } = new();

    public IActionResult OnGet(int id)
    {
        var room = RoomStore.Rooms.FirstOrDefault(r => r.Id == id);
        if (room == null) return NotFound();
        Room = room;
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

        var existing = RoomStore.Rooms.FirstOrDefault(r => r.Id == Room.Id);
        if (existing == null) return NotFound();

        existing.Number = Room.Number;
        existing.Category = Room.Category;
        existing.Capacity = Room.Capacity;
        existing.PricePerNight = Room.PricePerNight;
        existing.IsAvailable = Room.IsAvailable;
        existing.Description = Room.Description;
        if (!string.IsNullOrWhiteSpace(Room.ImageUrl))
            existing.ImageUrl = Room.ImageUrl;

        return RedirectToPage("./Index");
    }
}
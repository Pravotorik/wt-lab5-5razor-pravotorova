using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_pravotorova.Data;
using wt_lab5_5razor_pravotorova.Models;

namespace wt_lab5_5razor_pravotorova.Pages.Rooms;

public class CreateModel : PageModel
{
    [BindProperty]
    public Room Room { get; set; } = new();

    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

        Room.Id = RoomStore.Rooms.Any() ? RoomStore.Rooms.Max(r => r.Id) + 1 : 1;
        if (string.IsNullOrWhiteSpace(Room.ImageUrl))
            Room.ImageUrl = "https://images.unsplash.com/photo-1566073771259-6a8506099945?w=800";

        RoomStore.Rooms.Add(Room);
        return RedirectToPage("./Index");
    }
}
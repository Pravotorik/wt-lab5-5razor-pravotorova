using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_pravotorova.Data;
using wt_lab5_5razor_pravotorova.Models;

namespace wt_lab5_5razor_pravotorova.Pages.Rooms;

public class DetailsModel : PageModel
{
    public Room? Room { get; set; }

    public IActionResult OnGet(int id)
    {
        Room = RoomStore.Rooms.FirstOrDefault(r => r.Id == id);
        if (Room == null) return NotFound();
        return Page();
    }

    public IActionResult OnPostDelete(int id)
    {
        var room = RoomStore.Rooms.FirstOrDefault(r => r.Id == id);
        if (room != null) RoomStore.Rooms.Remove(room);
        return RedirectToPage("./Index");
    }
}
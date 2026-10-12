using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_pravotorova.Data;
using wt_lab5_5razor_pravotorova.Models;

namespace wt_lab5_5razor_pravotorova.Pages.Rooms;

public class IndexModel : PageModel
{
    public List<Room> Rooms { get; set; } = new();

    public void OnGet()
    {
        Rooms = RoomStore.Rooms;
    }
}
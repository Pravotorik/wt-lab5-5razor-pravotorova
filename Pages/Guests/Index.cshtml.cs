using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_pravotorova.Data;
using wt_lab5_5razor_pravotorova.Models;

namespace wt_lab5_5razor_pravotorova.Pages.Guests;

public class IndexModel : PageModel
{
    public List<Guest> Guests { get; set; } = new();

    public void OnGet()
    {
        Guests = GuestStore.Guests;
    }
}
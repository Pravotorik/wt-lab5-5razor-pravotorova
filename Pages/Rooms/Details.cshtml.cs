using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab8_8razor_postgresql_pravotorova.Data;
using wt_lab8_8razor_postgresql_pravotorova.Models;

namespace wt_lab8_8razor_postgresql_pravotorova.Pages.Rooms;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _context;

    public DetailsModel(AppDbContext context)
    {
        _context = context;
    }

    public Room Room { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var room = await _context.Rooms.FirstOrDefaultAsync(m => m.Id == id);
        if (room == null) return NotFound();

        Room = room;
        return Page();
    }
}
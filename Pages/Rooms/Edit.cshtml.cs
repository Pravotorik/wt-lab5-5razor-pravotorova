using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab8_8razor_postgresql_pravotorova.Data;
using wt_lab8_8razor_postgresql_pravotorova.Models;

namespace wt_lab8_8razor_postgresql_pravotorova.Pages.Rooms;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;

    public EditModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Room Room { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var room = await _context.Rooms.FindAsync(id);
        if (room == null) return NotFound();

        Room = room;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Room).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Rooms.Any(e => e.Id == Room.Id)) return NotFound();
            else throw;
        }

        return RedirectToPage("./Index");
    }
}
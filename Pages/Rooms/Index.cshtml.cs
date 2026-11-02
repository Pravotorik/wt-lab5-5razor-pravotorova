using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_pravotorova.Data;
using wt_lab8_8razor_postgresql_pravotorova.Models;

namespace wt_lab8_8razor_postgresql_pravotorova.Pages.Rooms;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public IList<Room> Rooms { get; set; } = default!;

    [BindProperty(SupportsGet = true)]
    public string? Search { get; set; }

    public async Task OnGetAsync()
    {
        var query = _context.Rooms.AsQueryable();

        if (!string.IsNullOrWhiteSpace(Search))
        {
            query = query.Where(r => r.Number.Contains(Search) || r.Category.Contains(Search));
        }

        Rooms = await query.OrderBy(r => r.Number).ToListAsync();
    }
}
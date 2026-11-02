using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_pravotorova.Data;
using wt_lab8_8razor_postgresql_pravotorova.Models;

namespace wt_lab8_8razor_postgresql_pravotorova.Pages.Guests;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public IList<Guest> Guests { get; set; } = default!;

    public async Task OnGetAsync()
    {
        // ѕолучаем список гостей из базы данных PostgreSQL
        Guests = await _context.Guests.ToListAsync();
    }
}
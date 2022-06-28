using Agenda.Data;
using Agenda.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Pages.Categorias
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public IndexModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Categoria> Categorias { get; set; }
        public async Task OnGet()
        {
            Categorias = await db.Categorias.ToListAsync();
        }
    }
}

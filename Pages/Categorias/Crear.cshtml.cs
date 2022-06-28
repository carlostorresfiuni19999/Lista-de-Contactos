using Agenda.Data;
using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agenda.Pages.Categorias
{
    public class CrearModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public CrearModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Categoria Categoria { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await db.Categorias.AddAsync(Categoria);
                await db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }

        }
    }
}

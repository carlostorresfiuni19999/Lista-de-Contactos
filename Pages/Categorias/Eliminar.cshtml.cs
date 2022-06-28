using Agenda.Data;
using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agenda.Pages.Categorias
{
    public class EliminarModel : PageModel
    {
        private readonly ApplicationDbContext db;
        [BindProperty]
        public Categoria Categoria { get; set; }


        public EliminarModel(ApplicationDbContext db)
        {
            this.db = db;
        }


        public void OnGet(int id)
        {
            Categoria = db.Categorias.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            db.Categorias.Remove(Categoria);
            await db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}

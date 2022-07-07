using Agenda.Data;
using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Pages.Categorias
{
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public EditarModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Categoria? Categoria { get; set; }

        public async void OnGet(int id)
        {
            Categoria = await db.Categorias.FindAsync(id);

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var CategoriaDb = await db.Categorias.FindAsync(Categoria.Id);

                if(CategoriaDb == null)
                {
                    return Page();
                }
                CategoriaDb.Nombre = Categoria.Nombre;
                CategoriaDb.FechaCreacion = Categoria.FechaCreacion;
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

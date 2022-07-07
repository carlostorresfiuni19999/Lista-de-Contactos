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

        public IActionResult OnPost()
        {
            var Contactos = db.Contactos
                 .Where(c => c.IdCategoria == Categoria.Id);

            if(Contactos.Count() > 0)
            {
                foreach (var contact in Contactos)
                {
                    contact.IdCategoria = null;
                    contact.Categoria = null;

                    db.Entry(contact).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
            }
            
              
            db.Categorias.Remove(Categoria);
            db.SaveChanges();
            return RedirectToPage("./Index");
        }
    }
}

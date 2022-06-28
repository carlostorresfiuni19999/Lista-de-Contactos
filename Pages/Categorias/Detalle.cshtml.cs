using Agenda.Data;
using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agenda.Pages.Categorias
{
    public class DetalleModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public DetalleModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        [BindProperty]
        public Categoria Categoria { get; set; }
        public void OnGet(int id)
        {
            Categoria = db.Categorias.Find(id);
        }
    }
}

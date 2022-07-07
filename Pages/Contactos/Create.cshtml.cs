using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Agenda.Data;
using Agenda.Models;

namespace Agenda.Pages.Contactos
{
    public class CreateModel : PageModel
    {
        private readonly Agenda.Data.ApplicationDbContext _context;

        public CreateModel(Agenda.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IdCategoria"] = new SelectList(_context.Categorias, "Id", "Nombre");
            return Page();
        }

        [BindProperty]
        public ContactoRequestDTO Contacto { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Contactos == null || Contacto == null)
            {
                return Page();
            }
            var ContactoDb = new Contacto()
            {
                Nombre = Contacto.Nombre,
                Apellido = Contacto.Apellido,
                FechaCreacion = DateTime.Now,
                IdCategoria = Contacto.IdCategoria,
                Telefono = Contacto.Telefono
            };
            await _context.Contactos.AddAsync(ContactoDb);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

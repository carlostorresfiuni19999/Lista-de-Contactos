using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agenda.Data;
using Agenda.Models;

namespace Agenda.Pages.Contactos
{
    public class EditModel : PageModel
    {
        private readonly Agenda.Data.ApplicationDbContext _context;

        public EditModel(Agenda.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ContactoEditRequestDTO Contacto { get; set; } = new ContactoEditRequestDTO();
        public List<SelectListItem> Options { get; set; } = new List<SelectListItem>();
        public async Task<IActionResult> OnGetAsync(int id)
        {

            Contacto? contacto =  await _context.Contactos
                .Include(c => c.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if(contacto == null)
            {
                return NotFound();
            }
            
            Options = _context.Categorias
                    .ToList()
                   .ConvertAll(c => new SelectListItem()
                   {
                       Value = c.Id.ToString(),
                       Text = c.Nombre
                   });
            Contacto.Id = contacto.Id;  
            Contacto.Nombre = contacto.Nombre;
            Contacto.Apellido = contacto.Apellido;
            Contacto.Telefono = contacto.Telefono;
            Contacto.IdCategoria = contacto.IdCategoria == null ? null : contacto.IdCategoria;
            return Page();
  
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {

                return BadRequest("Argumentos no validos");
            }
            var ContactoDb = await _context.Contactos
                .Include(c => c.Categoria)
                .FirstOrDefaultAsync(c => c.Id == Contacto.Id);

            Console.WriteLine($"Id Recibido = {ContactoDb.Id}");

            if (ContactoDb == null) return NotFound();
            ContactoDb.Nombre = Contacto.Nombre;
            ContactoDb.Apellido = Contacto.Apellido;
            ContactoDb.Telefono = Contacto.Telefono;
            ContactoDb.IdCategoria = Contacto.IdCategoria;

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            
            

           
        }

        private bool ContactoExists(int id)
        {
          return (_context.Contactos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Agenda.Data;
using Agenda.Models;

namespace Agenda.Pages.Contactos
{
    public class DeleteModel : PageModel
    {
        private readonly Agenda.Data.ApplicationDbContext _context;

        public DeleteModel(Agenda.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Contacto Contacto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Contactos == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contactos.FirstOrDefaultAsync(m => m.Id == id);

            if (contacto == null)
            {
                return NotFound();
            }
            else 
            {
                Contacto = contacto;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
         _context.Contactos.Remove(Contacto);
         await _context.SaveChangesAsync();
         return RedirectToPage("./Index");
        }
    }
}

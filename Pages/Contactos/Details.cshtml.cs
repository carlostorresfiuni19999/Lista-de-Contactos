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
    public class DetailsModel : PageModel
    {
        private readonly Agenda.Data.ApplicationDbContext _context;

        public DetailsModel(Agenda.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Contacto Contacto { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Contactos == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contactos
                .Include(c => c.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
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
    }
}

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
    public class IndexModel : PageModel
    {
        private readonly Agenda.Data.ApplicationDbContext _context;

        public IndexModel(Agenda.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Contacto> Contacto { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Contactos != null)
            {
                Contacto = await _context.Contactos
                .Include(c => c.Categoria).ToListAsync();
            }
        }
    }
}

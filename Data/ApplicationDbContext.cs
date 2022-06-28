using Agenda.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Categoria> Categorias { get; set; }
    }
}

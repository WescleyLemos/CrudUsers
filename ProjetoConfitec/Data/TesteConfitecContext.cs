using Microsoft.EntityFrameworkCore;
using ProjetoConfitec.Models;

namespace ProjetoConfitec.Data
{
    public class TesteConfitecContext : DbContext
    {
        public TesteConfitecContext(DbContextOptions<TesteConfitecContext> options) : base(options) { }

        public DbSet<Usuarios> Usuarios { get; set; }
    }
}

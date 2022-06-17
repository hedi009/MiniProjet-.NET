using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace miniProjet.Models
{
    public class EmployeContext : IdentityDbContext
    {
        public EmployeContext(DbContextOptions<EmployeContext> options) : base(options)
        {
        }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<Entreprise> Entreprises { get; set; }
    }
}

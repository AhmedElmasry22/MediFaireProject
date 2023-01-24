using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MediaFaire.Data
{
    public class AplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public AplicationDbContext(DbContextOptions option):base(option) { }
        public DbSet<Uploads> uploads { get; set; }
        public DbSet<Contact> contacts { get; set; }
    }
}

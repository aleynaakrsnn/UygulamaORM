using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UygulamaORM.Models;

namespace UygulamaORM.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
 public DbSet<Urunler> Urunlers { get; set; }
        public DbSet<Kategori>Kategoris { get; set; }   
    
    
    }
}
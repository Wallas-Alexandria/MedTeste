using MedTeste.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedTeste.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Contato> Contatos { get; set; }
    }
}

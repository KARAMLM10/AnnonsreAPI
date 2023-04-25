using AnnonsreAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AnnonsreAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Annons> Annonser { get; set; }
    }

}

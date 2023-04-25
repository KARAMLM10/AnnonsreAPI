using AnnonsreAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AnnonsreAPI.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void MigrateData()
        {
            _dbContext.Database.Migrate();
            SeedData();
            _dbContext.SaveChanges();
        }

        private void SeedData()
        {
            if (!_dbContext.Annonser
                    .Any(e => e.AnnonsId == 1))
            {
                _dbContext.Add(new Annons
                {
                    Name = "Super Richard",
                    FirstName = "Richard",
                    SurName = "Chalk",
                    City = "York",
                });
            };
        }
    }

}

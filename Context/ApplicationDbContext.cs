using Microsoft.EntityFrameworkCore;
using Pharmacy.Entities;

namespace Pharmacy.Context
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<MedicalDrugsEntity> medicalDrugs { get; set; }
    }
}

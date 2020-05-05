using System.Data.Entity;

namespace lab8.Models
{
    class PeopleContext : DbContext
    {
        public PeopleContext() : base("DbConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<PeopleContext>());
        }

        public DbSet<People> Peoples { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Weather> Weathers { get; set; }
    }
}

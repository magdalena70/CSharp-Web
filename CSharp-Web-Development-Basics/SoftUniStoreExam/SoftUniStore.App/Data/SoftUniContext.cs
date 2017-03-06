namespace SoftUniStore.App.Data
{
    using Models;
    using System.Data.Entity;

    public class SoftUniContext : DbContext
    {
        public SoftUniContext()
            : base("name=SoftUniContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
    }
}
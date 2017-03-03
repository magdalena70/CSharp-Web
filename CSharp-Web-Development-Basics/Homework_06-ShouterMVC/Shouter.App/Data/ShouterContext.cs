namespace Shouter.App.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ShouterContext : DbContext
    {
        public ShouterContext()
            : base("name=ShouterContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Shout> Shout { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
    }
}
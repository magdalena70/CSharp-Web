namespace PizzaMore.App.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PizzaMoreContext : DbContext
    {
        public PizzaMoreContext()
            : base("name=PizzaMoreContext")
        {
        }

        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
    }
}
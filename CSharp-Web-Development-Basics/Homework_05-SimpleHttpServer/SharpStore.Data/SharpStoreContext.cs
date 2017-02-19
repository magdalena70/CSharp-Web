namespace SharpStore.Data
{
    using Models;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class SharpStoreContext : DbContext
    {
        public SharpStoreContext()
            : base("name=SharpStoreContext")
        {
        }

        public virtual DbSet<Knife> Knives { get; set; }

        public virtual DbSet<Message> Messages { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
               .HasRequired(m => m.Sender)
               .WithMany(s => s.SendedMessages)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
               .HasRequired(m => m.Subject)
               .WithMany(s => s.ReceivedMessages)
               .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
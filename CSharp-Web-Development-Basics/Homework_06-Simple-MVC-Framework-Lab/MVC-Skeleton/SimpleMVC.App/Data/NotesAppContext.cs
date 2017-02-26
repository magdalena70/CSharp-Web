namespace SimpleMVC.App.Data
{
    using Models;
    using MVC.Interfaces;
    using System.Data.Entity;

    public class NotesAppContext : DbContext, IDbIdentityContext
    {
        public NotesAppContext()
            : base("name=NotesAppContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public DbSet<Login> Logins { get; set; }

        void IDbIdentityContext.SaveChanges()
        {
            this.SaveChanges();
        }
    }
}
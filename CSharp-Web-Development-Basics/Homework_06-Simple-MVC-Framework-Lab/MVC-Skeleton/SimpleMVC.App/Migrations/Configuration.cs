namespace SimpleMVC.App.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleMVC.App.Data.NotesAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SimpleMVC.App.Data.NotesAppContext";
        }

        protected override void Seed(SimpleMVC.App.Data.NotesAppContext context)
        {
        }
    }
}

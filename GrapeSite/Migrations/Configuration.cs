namespace GrapeSite.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GrapeSite.Models.GrapeFazendaContext>
    {
    
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "GrapeSite.GrapeFazendaContext";
        }

        protected override void Seed(GrapeSite.Models.GrapeFazendaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}

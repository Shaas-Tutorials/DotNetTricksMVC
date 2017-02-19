namespace EF_Start.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EF_Start.DAL.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EF_Start.DAL.DatabaseContext";
        }

        protected override void Seed(EF_Start.DAL.DatabaseContext context)
        {
            
        }
    }
}

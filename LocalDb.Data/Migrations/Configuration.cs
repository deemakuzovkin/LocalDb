using LocalDb.Data.Entities;

namespace LocalDb.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.LocalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context.LocalContext context)
        {
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        }
    }
}

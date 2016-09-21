namespace LinqEntityFrameworkDemo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LinqEntityFrameworkDemo.Entities.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "LinqEntityFrameworkDemo.Entities.LibraryContext";
        }

        protected override void Seed(LinqEntityFrameworkDemo.Entities.LibraryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Authors.AddOrUpdate(
                a => a.Name,
                new Entities.Author { Name = "Douglas Adams" },
                new Entities.Author { Name = "Hunter S. Thompson" }
                );
            context.Books.AddOrUpdate(
                b => b.Title,
                new Entities.Book { AuthorId = 1, Title = "Hitchhikers Guide To The Galaxy"},
                new Entities.Book { AuthorId = 1, Title = "So Long And Thanks For All The Fish" },
                new Entities.Book { AuthorId = 2, Title = "Fear And Loathing In Las Vegas" }
                );
        }
    }
}

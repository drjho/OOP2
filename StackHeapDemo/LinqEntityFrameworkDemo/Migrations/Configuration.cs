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
            var da = "Douglas Adams";
            var hst = "Hunter S. Thompson";
            context.Authors.AddOrUpdate(
                a => a.Name,
                new Entities.Author { Name = da },
                new Entities.Author { Name = hst }
                );
            context.SaveChanges();
            var daId = context.Authors.Single(a => a.Name.Equals(da)).Id;
            var hstId = context.Authors.Single(a => a.Name.Equals(hst)).Id;
            context.Books.AddOrUpdate(
                b => b.Title,
                new Entities.Book { AuthorId = daId, Title = "Hitchhikers Guide To The Galaxy"},
                new Entities.Book { AuthorId = daId, Title = "So Long And Thanks For All The Fish" },
                new Entities.Book { AuthorId = hstId, Title = "Fear And Loathing In Las Vegas" }
                );
        }
    }
}

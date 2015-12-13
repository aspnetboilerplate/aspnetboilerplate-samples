namespace MultipleDbContextDemo.MigrationsSecond
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MultipleDbContextDemo.EntityFramework.MySecondDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"MigrationsSecond";
        }

        protected override void Seed(MultipleDbContextDemo.EntityFramework.MySecondDbContext context)
        {
            context.Courses.AddOrUpdate(c => c.CourseName,
                new Course("Mathematics"),
                new Course("Physics")
                );
        }
    }
}

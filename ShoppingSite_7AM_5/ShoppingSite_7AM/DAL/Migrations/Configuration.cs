namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.DatabaseContext context)
        {
            Role r1 = new Role { Name = "Admin",Description="Administration" };
            Role r2 = new Role { Name = "User", Description = "End User" };

            User u1 = new User
            {
                Username = "admin@gmail.com",
                Name="Admin",
                Password="123456",
                Address = "Noida",
                ContactNo = "8687675675",
                CreatedDate = DateTime.Now
            };

            User u2 = new User
            {
                Username = "user@gmail.com",
                Name="User",
                Password="123456",
                Address = "Delhi",
                ContactNo = "675765765",
                CreatedDate = DateTime.Now
            };
            u1.Roles.Add(r1);
            u2.Roles.Add(r2);

            context.Users.Add(u1);
            context.Users.Add(u2);
        }
    }
}

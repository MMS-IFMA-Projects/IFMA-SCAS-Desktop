using Npgsql;
using System;
using System.IO;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;

namespace IFMA_SCAS_Desktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Set base path
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true); // Load JSON file

            IConfiguration config = builder.Build();

            using (var context = new AppDbContext())
            {
                // Ensure database is created (for testing purposes)
                context.Database.EnsureCreated();

                /* Add a new user
                var newUser = new Entities.User { Name = "Alice", Email = "alice@example.com" };
                context.Users.Add(newUser);
                context.SaveChanges();
                */
                
                // Retrieve and display users
                var users = context.Users.ToList();
                Console.WriteLine("Users in database:");
                foreach (var user in users)
                {
                    Console.WriteLine($"ID: {user.id}, Name: {user.name}, Email: {user.email}");
                }
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());

        }
    }
}
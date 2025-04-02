using Npgsql;
using System;
using System.IO;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
using Repositories;

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
            UserRepository user = new();
            user.createUser("Robs", "rob@algo.com", "1234", "012354", "9898989");

            //readAllUsersTest();

            /*
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
            }
            */

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Login());

        }
    
        async static void readAllUsersTest()
        {
            UserRepository user = new();

            Entities.User userTest = await user.GetUserByIdAsync(1);
            Console.WriteLine(userTest.name);
        }
    }
}
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
            UserRepository user = new UserRepository();
            user.createUser(1, "Robs", "robs@algo.com", "1234", "01234", "aloalo");

            /*
             * using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
            }
            */

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());

        }
    }
}
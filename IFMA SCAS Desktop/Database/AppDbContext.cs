using System.Text.Json;
using System;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Entities.User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        /*string filePath = "appsettings.json";
        string jsonString = File.ReadAllText(filePath);

        // Deserialize JSON into a C# object
        Person person = JsonSerializer.Deserialize<Person>(jsonString);*/


        string[] connectionString = {
            "Host=hardily-jointed-stud.data-1.use1.tembo.io",
            "Server=postgresql://postgres:d7Lxtw6E1yI0gXFa@hardily-jointed-stud.data-1.use1.tembo.io:5432/postgres",
            "Database=sas",
            "User Id=postgres",
            "Password=d7Lxtw6E1yI0gXFa",
            "Trusted_Connection=True"
        };

        optionsBuilder.UseNpgsql(string.Join(";", connectionString));
    }
}

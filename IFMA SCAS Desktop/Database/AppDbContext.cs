using System.Text.Json;
using System.Xml.Linq;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

/*
    URI: postgresql://postgres:d7Lxtw6E1yI0gXFa@hardily-jointed-stud.data-1.use1.tembo.io:5432/postgres
    Hostname: hardily-jointed-stud.data-1.use1.tembo.io
    Porta: 5432
    Username: postgres
    Password: d7Lxtw6E1yI0gXFa
 */

public class AppDbContext : DbContext
{
    //public DbSet<Entities.Request> Requests { get; set; }
    //public DbSet<Entities.RequestType> RequestTypes { get; set; }
    //public DbSet<Entities.Role> Roles { get; set; }
    //public DbSet<Entities.Room> Rooms { get; set; }
    //public DbSet<Entities.RoomAssignment> RoomAssignments { get; set; }
    //public DbSet<Entities.Session> Sessions { get; set; }
    public DbSet<Entities.User> Users { get; set; }
    //public DbSet<Entities.UserType> UserTypes { get; set; }

    protected readonly string connectionString;
    private const string ConnectionFilePath = "appsettings.json";

    public AppDbContext()
    {
        string directory = AppContext.BaseDirectory;
        string combinedPath = Path.Combine(directory, ConnectionFilePath);

        while (directory != null && !File.Exists(combinedPath))
        {
            directory = Directory.GetParent(directory)?.FullName ?? throw new NullReferenceException("Unable to find connection file");
            combinedPath = Path.Combine(directory, ConnectionFilePath);
        }

        string jsonString = File.ReadAllText(combinedPath) ?? throw new NullReferenceException("Unable to find connection file");
        var data = JsonSerializer.Deserialize<JsonConfigFile>(jsonString) ?? throw new NullReferenceException("Failed to deserialize JSON file");

        this.connectionString = data.ConnectionStrings.getConnectionString();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(this.connectionString);
    }
    
    protected class JsonConfigFile
    {
        public ConnectionData ConnectionStrings { get; set; }
    }

    protected class ConnectionData
    {
        public string Host{ get; set; }
        public string Port { get; set; }
        public string Database { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }

        public string getConnectionString()
        {
            string[] connectionArgs = {
                "Host=" + this.Host,
                "Port=" + this.Port,
                "Database=" + this.Database,
                "User Id=" + this.UserId,
                "Password=" + this.Password
            };
            return string.Join(";", connectionArgs);
        }
    }
}

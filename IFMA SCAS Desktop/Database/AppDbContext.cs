using System.Text.Json;
using System.Xml.Linq;
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
    protected readonly string connectionString;
    public DbSet<Entities.User> Users { get; set; }
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

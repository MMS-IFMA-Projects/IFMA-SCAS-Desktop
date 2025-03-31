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
    protected readonly IConfiguration configuration;
    public DbSet<Entities.User> Users { get; set; }

    public AppDbContext(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        /*
        string connectionString = this.configuration.GetConnectionString("DBConnection");
        connectionString = string.Join(";", connectionString);
        */

        string[] connectionArgs = {
            "Host=hardily-jointed-stud.data-1.use1.tembo.io",
            //"Server=:5432/postgres",
            "Port=5432",
            "Database=sas",
            "User Id=postgres",
            "Password=d7Lxtw6E1yI0gXFa" 
        };

        string connectionString = string.Join(";", connectionArgs);

        optionsBuilder.UseNpgsql(connectionString);
    }
    /*
    protected override void OnConfiguring()
    {
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
    */
}

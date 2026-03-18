using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Employee.Configuration;

public class EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : DbContext(options)
{
    public const string DATA_SOURCE = "Data Source=C:\\data\\employee.db;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(DATA_SOURCE);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        CreateTables();
        modelBuilder.Entity<Entities.Employee>().ToTable("Employees");
    }

    private static void CreateTables()
    {
        const string CREATE_TABLES_SQL = @$"
                CREATE TABLE IF NOT EXISTS Employees(
                    Id TEXT PRIMARY KEY NOT NULL,
                    LastUpdate TEXT NOT NULL,
                    Code TEXT NOT NULL,
                    Name TEXT NOT NULL,
                    Deleted TEXT NOT NULL DEFAULT 0,
                    IsPriority TEXT NOT NULL DEFAULT 0,
                    SearchText TEXT NULL
                );
            ";

        using var dbConnection = new SqliteConnection(DATA_SOURCE);
        dbConnection.Open();
        using var dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = CREATE_TABLES_SQL;
        dbCommand.ExecuteNonQuery();
    }
}

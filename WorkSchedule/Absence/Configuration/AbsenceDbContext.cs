using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Absence.Configuration;

public class AbsenceDbContext(DbContextOptions<AbsenceDbContext> options) : DbContext(options)
{
    public const string DATA_SOURCE = "Data Source=C:\\data\\absence.db;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(DATA_SOURCE);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        CreateTables();

        modelBuilder.Entity<Models.Absence>().ToTable("Absences");
    }

    private static void CreateTables()
    {
        var createTablesSql = @$"
                CREATE TABLE IF NOT EXISTS Absences(
                    Id TEXT PRIMARY KEY NOT NULL,
                    LastUpdate TEXT NOT NULL,
                    Start TEXT NOT NULL,
                    End   TEXT NOT NULL,
                    Cause INTEGER NOT NULL,
                    EmployeeId TEXT NOT NULL
                );
            ";

        using var dbConnection = new SqliteConnection(DATA_SOURCE);
        dbConnection.Open();
        using var dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = createTablesSql;
        dbCommand.ExecuteNonQuery();
    }


}

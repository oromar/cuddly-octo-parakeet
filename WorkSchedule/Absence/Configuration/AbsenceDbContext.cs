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
        modelBuilder.Entity<Entities.Absence>().ToTable("Absences");
    }

    private static void CreateTables()
    {
        const string CREATE_TABLES_SQL = @$"
                CREATE TABLE IF NOT EXISTS Absences(
                    Id TEXT PRIMARY KEY NOT NULL,
                    LastUpdate TEXT NOT NULL,
                    Start TEXT NOT NULL,
                    End   TEXT NOT NULL,
                    Cause INTEGER NOT NULL,
                    Deleted TEXT NOT NULL DEFAULT 0,
                    EmployeeId TEXT NOT NULL
                );
            ";

        using var dbConnection = new SqliteConnection(DATA_SOURCE);
        dbConnection.Open();
        using var dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = CREATE_TABLES_SQL;
        dbCommand.ExecuteNonQuery();
    }


}

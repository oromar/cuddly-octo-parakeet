
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Settings.Configuration;

public class SettingsDbContext(DbContextOptions<SettingsDbContext> options) : DbContext(options)
{
    public const string DATA_SOURCE = "Data Source=C:\\data\\settings.db;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(DATA_SOURCE);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        CreateTables();

        modelBuilder.Entity<Models.Settings>().ToTable("Settings");
    }

    private static void CreateTables()
    {
        const string CREATE_TABLES_SQL = @$"
                CREATE TABLE IF NOT EXISTS Settings(
                    Id TEXT PRIMARY KEY NOT NULL,
                    LastUpdate TEXT NOT NULL,
                    EmployeesPerDateInOnNoticeSchedule INTEGER NOT NULL DEFAULT 0,
                    DaysToCheckOnNoticeSchedule INTEGER NOT NULL DEFAULT 0
                );
            ";

        using var dbConnection = new SqliteConnection(DATA_SOURCE);
        dbConnection.Open();
        using var dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = CREATE_TABLES_SQL;
        dbCommand.ExecuteNonQuery();
    }


}

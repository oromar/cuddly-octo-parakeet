using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Models;

namespace WorkSchedule.Infra.Context
{
    public class WorkScheduleContext: DbContext
    {
        public const string DATA_SOURCE = "Data Source=C:\\data\\WorkSchedule.db;";
        public WorkScheduleContext(DbContextOptions<WorkScheduleContext> options): base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(DATA_SOURCE);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateTables();

            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Absence>().ToTable("Absences");
            modelBuilder.Entity<Settings>().ToTable("Settings");
        }

        private void CreateTables()
        {
            var createTablesSql = @$"
                CREATE TABLE IF NOT EXISTS Employees(
                    Id TEXT PRIMARY KEY NOT NULL,
                    CreationTime TEXT NOT NULL,
                    EmployeeCode TEXT NOT NULL,
                    Name TEXT NOT NULL,
                    FirstSchedule TEXT NOT NULL DEFAULT 0,
                    SearchText TEXT NULL
                );
                CREATE TABLE IF NOT EXISTS Absences(
                    Id TEXT PRIMARY KEY NOT NULL,
                    CreationTime TEXT NOT NULL,
                    Start TEXT NOT NULL,
                    End   TEXT NOT NULL,
                    Cause INTEGER NOT NULL,
                    EmployeeId TEXT NOT NULL
                );
                CREATE TABLE IF NOT EXISTS Settings(
                    Id TEXT PRIMARY KEY NOT NULL,
                    CreationTime TEXT NOT NULL,
                    EmployeesPerDateInOnNoticeSchedule INTEGER NOT NULL DEFAULT 0,
                    DaysToCheckOnNoticeSchedule INTEGER NOT NULL DEFAULT 0
                );
            ";

            using var dbConnection = new SqliteConnection(DATA_SOURCE);
            dbConnection.Open();
            using var dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = createTablesSql;
            dbCommand.ExecuteNonQuery();
        }
    }
}

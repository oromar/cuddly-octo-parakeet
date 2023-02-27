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

        public WorkScheduleContext(DbContextOptions<WorkScheduleContext> options): base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=WorkSchedule.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateTables();

            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Absence>().ToTable("Absences");
        }

        private void CreateTables()
        {
            var createTablesSql = @"
                CREATE TABLE IF NOT EXISTS Employees(
                    Id TEXT PRIMARY KEY NOT NULL,
                    CreationTime TEXT NOT NULL,
                    EmployeeCode TEXT NOT NULL,
                    Name TEXT NOT NULL,
                    NotFirstSchedule TEXT NOT NULL DEFAULT 0
                );
                CREATE TABLE IF NOT EXISTS Absences(
                    Id TEXT PRIMARY KEY NOT NULL,
                    CreationTime TEXT NOT NULL,
                    Start TEXT NOT NULL,
                    End   TEXT NOT NULL,
                    Cause INTEGER NOT NULL,
                    EmployeeId TEXT NOT NULL
                );

            ";

            using (var dbConnection = new SqliteConnection("Data Source=WorkSchedule.db;"))
            {
                dbConnection.Open();
                using (var dbCommand = dbConnection.CreateCommand())
                {
                    dbCommand.CommandText = createTablesSql;
                    dbCommand.ExecuteNonQuery();
                }
            }
        }
    }
}

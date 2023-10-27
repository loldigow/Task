using DBSqlLite.SqlLiteModels;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DBSqlLite
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={BancoSqlite.CaminhoDoBanco}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskSQLiteModel>();
            modelBuilder.Entity<UsuarioSQLiteModel>();
        }
    }

}

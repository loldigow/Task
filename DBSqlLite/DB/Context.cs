using DBSqlLite.SqlLiteModels;
using Microsoft.EntityFrameworkCore;

namespace DB.Repository
{
    public class Context<TEntity> : DbContext where TEntity : SqlModelbase
    {
        public DbSet<TEntity> Contexto { get; set; }

        public Context()
        {
             Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={BancoSqlite.CaminhoDoBanco}");
        }
    }
}

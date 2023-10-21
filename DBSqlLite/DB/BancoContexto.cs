using Microsoft.EntityFrameworkCore;

namespace DB.Repository
{
    public class BancoContexto<TEntity> : DbContext where TEntity : class
    {
        public DbSet<TEntity> Tentity { get; set; }

        public BancoContexto()
        {
             Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={Constants.BancoDeDados}");
        }
    }
}

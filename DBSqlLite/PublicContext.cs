using AutoMapper.Internal;
using DBSqlLite.SqlLiteModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBSqlLite
{
    public class PublicContext : DbContext
    {
        DbSet<TaskSQLiteModel> BancoTask;
        DbSet<UsuarioSQLiteModel> BancoUsuario;

        internal PublicContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={BancoSqlite.CaminhoDoBanco}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<TaskSQLiteModel>();
            //modelBuilder.Entity<UsuarioSQLiteModel>();
        }
    }
}

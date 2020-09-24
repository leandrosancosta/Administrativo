using System.Data.Entity;
using MySql.Data.Entity;
using WApp.Service.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WApp.Service.Context
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DataContext : DbContext
    {
        public DataContext() : base("dbMyApp")
        {
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Situacao> Situacoes { get; set; }
        public DbSet<Cobranca> Cobrancas { get; set; }
    }
}
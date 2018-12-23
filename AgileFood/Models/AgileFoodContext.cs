using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AgileFood.Models
{
    public class AgileFoodContext : DbContext
    {
        public AgileFoodContext() : base("DefaultConnection")//ConexaoTeste
        {

        }

        /* Desabilitar exclusão em cascata
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        */

        public DbSet<PessoaTipos> PessoaTipos { get; set; }

        public DbSet<Pessoas> Pessoas { get; set; }

        public DbSet<PessoaFisicas> PessoaFisicas { get; set; }

        public DbSet<PessoaJuridicas> PessoaJuridicas { get; set; }

        public System.Data.Entity.DbSet<AgileFood.Models.Fornecedores> Fornecedores { get; set; }

        public System.Data.Entity.DbSet<AgileFood.Models.Funcionarios> Funcionarios { get; set; }
    }
}
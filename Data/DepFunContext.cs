using API_Dep_Fun.Data.Map;
using API_Dep_Fun.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Dep_Fun.Data
{
    public class DepFunContext : DbContext
    {
        public DepFunContext(DbContextOptions<DepFunContext> options)
            : base(options)
        {   
        }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartamentoMap());
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}

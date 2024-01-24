using API_Dep_Fun.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Dep_Fun.Data.Map
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Foto).IsRequired().HasMaxLength(30);
            builder.Property(x => x.RG).IsRequired().HasMaxLength(9);
            builder.HasOne<Departamento>().WithMany().HasForeignKey(x => x.DepartamentoId).IsRequired();
        }
    }
}

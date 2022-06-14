using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Core.Entities;

namespace ToDoList.Infraestructure.Data.Configurations
{
    public class TareaConfiguration : IEntityTypeConfiguration<Tarea>
    {
        public void Configure(EntityTypeBuilder<Tarea> builder)
        {
            builder.HasKey(e => e.IdTarea);

            builder.ToTable("Tarea");

            builder.Property(e => e.Estado)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nombre");
        }
    }
}

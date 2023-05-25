using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Minimal_API_EF_Core_Oracle.Models;

namespace Minimal_API_EF_Core_Oracle.Data
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>

    {
        public void Configure( EntityTypeBuilder<TodoItem> builder )
        {
            builder.ToTable("TODOITEM");

            builder.HasKey(e => e.Id).HasName("SYS_C006997");
            
            builder.Property(e => e.Id)
                .HasColumnType("NUMBER(10, 0)")
                .HasColumnName("ID");

            builder.Property(e => e.CreationTs)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE")
                .HasColumnName("CREATION_TS");  

            builder.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");

            builder.Property(e => e.Done)
                .HasPrecision(1)
                .HasColumnName("DONE");
        }
    }
}

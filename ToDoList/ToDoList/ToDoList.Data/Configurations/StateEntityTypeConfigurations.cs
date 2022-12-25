using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Data.Models;

namespace ToDoList.Data.Configurations
{
    public class StateEntityTypeConfigurations : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("State");
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.CreationTime);
           // builder.Property(x => x.CreationTime).HasDefaultValueSql("CURDATE()");
        }
    }
}

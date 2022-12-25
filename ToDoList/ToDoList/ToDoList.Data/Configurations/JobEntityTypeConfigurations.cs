using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Data.Models;

namespace ToDoList.Data.Configurations
{
    public class JobEntityTypeConfigurations : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable("Job");
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.FromDate).IsRequired();
            builder.Property(x => x.ToDate).IsRequired();
          //  builder.Property(x => x.CreationTime).HasDefaultValueSql("CURDATE()");
        }
    }
}

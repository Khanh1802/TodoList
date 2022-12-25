using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Data.Models;

namespace ToDoList.Data.Configurations
{
    public class CategoryEntityTypeConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Mặc định là nvarchar nếu không muốn là nvarchar thì thêm unicode
            builder.ToTable("Category");
            builder.Property(x => x.Name).HasMaxLength(200);
            // builder.Property(x => x.CreationTime).HasDefaultValueSql("CURDATE()");
        }
    }
}

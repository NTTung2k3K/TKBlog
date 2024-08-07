using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Data.Entities;

namespace TKBlogSolution.Data.Configurations
{
  public class CategoryConfiguration : IEntityTypeConfiguration<Category>
  {
    public void Configure(EntityTypeBuilder<Category> builder)
    {
      builder.ToTable("Category");
      builder.HasKey(x => x.CategoryId);
      builder.Property(x => x.CategoryId).ValueGeneratedOnAdd().UseIdentityColumn();
      builder.Property(x => x.CategoryName).HasMaxLength(250).IsRequired();
      builder.Property(x => x.Description).HasMaxLength(400).IsRequired(false);
      builder.HasMany(x => x.Posts).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).IsRequired().OnDelete(DeleteBehavior.Restrict); ;

    }
  }
}

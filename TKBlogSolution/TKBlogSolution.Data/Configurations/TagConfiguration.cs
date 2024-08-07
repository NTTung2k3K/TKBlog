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
  public class TagConfiguration : IEntityTypeConfiguration<Tag>
  {
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
      builder.ToTable("Tag");
      builder.HasKey(x => x.TagId);
      builder.Property(x => x.TagName).HasMaxLength(250).IsRequired();
      builder.Property(x => x.Description).HasMaxLength(400).IsRequired(false);
      builder.HasMany(x => x.PostTags).WithOne(x => x.Tag).HasForeignKey(x => x.TagId).IsRequired();
    }
  }
}

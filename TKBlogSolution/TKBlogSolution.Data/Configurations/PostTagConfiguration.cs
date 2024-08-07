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
  public class PostTagConfiguration : IEntityTypeConfiguration<PostTag>
  {
    public void Configure(EntityTypeBuilder<PostTag> builder)
    {
      builder.ToTable("PostTag");
      builder.HasKey(x => new { x.PostId, x.TagId });
      builder.Property(x => x.Description).IsRequired(false).HasMaxLength(400);

      builder.HasOne(x => x.Post).WithMany(x => x.PostTags).HasForeignKey(x => x.PostId).IsRequired();
      builder.HasOne(x => x.Tag).WithMany(x => x.PostTags).HasForeignKey(x => x.TagId).IsRequired();
    }
  }
}

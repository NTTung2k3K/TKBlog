using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Data.Configurations;
using TKBlogSolution.Data.Entities;

namespace TKBlogSolution.Data.EF
{
  public class TKBlogSolutionContext : IdentityDbContext<AppUser, AppRole, Guid>
  {
    public TKBlogSolutionContext() { }
    public TKBlogSolutionContext(DbContextOptions<TKBlogSolutionContext> options) : base(options) { }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<PostTag> PostTags { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      // Option for config
      builder.ApplyConfiguration(new CategoryConfiguration());
      builder.ApplyConfiguration(new CommentConfiguration());
      builder.ApplyConfiguration(new PostConfiguration());
      builder.ApplyConfiguration(new PostTagConfiguration());
      builder.ApplyConfiguration(new TagConfiguration());

      base.OnModelCreating(builder);

    }
  }
}

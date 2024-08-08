using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKBlogSolution.Data.Entities
{
  public class Post
  {
    public int PostId { get; set; }
    public string PostTitle { get; set; } = string.Empty;
    public string PostBody { get; set; } = string.Empty;
    public string PostSummary { get; set; } = string.Empty;
    public int ViewCount { get; set; }
    public string Status { get; set; } = string.Empty;
    public string ThumbnailImage {  get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; } = new Category();
    public ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();
    public Guid UserId { get; set; }
    public AppUser User { get; set; } = new AppUser();

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKBlogSolution.Data.Entities
{
  public class Comment
  {
    public int CommentId { get; set; }
    public string Content { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }

    public Guid UserId { get; set; }
    public AppUser User { get; set; } = new AppUser();
    public int PostId { get; set; }
    public Comment? ResponseComment { get; set; }
    public int? ResponseCommentId { get; set; }
    public ICollection<Comment> ResponseComments { get; set; } = new HashSet<Comment>();

    public Post Post { get; set; } = new Post();
  }
}

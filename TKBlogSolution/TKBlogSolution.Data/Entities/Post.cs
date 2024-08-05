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
    public string PostTitle { get; set; }
    public string PostBody { get; set; }
    public string PostSummary { get; set; }
    public int ViewCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }

  }
}

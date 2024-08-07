using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKBlogSolution.Data.Entities
{
  public class PostTag
  {
    public int TagId { get; set; }
    public Tag Tag { get; set; } = new Tag();
    public int PostId { get; set; }
    public Post Post { get; set; } = new Post();
    public string Description { get; set; } = string.Empty;
  }
}

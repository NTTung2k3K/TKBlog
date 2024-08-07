using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKBlogSolution.Data.Entities
{
  public class Category
  {
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<Post> Posts { get; set; } = new List<Post>();
  }
}

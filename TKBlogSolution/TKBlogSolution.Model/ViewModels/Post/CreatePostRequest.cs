using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKBlogSolution.Model.ViewModels.Post
{
  public class CreatePostRequest
  {
    public string PostTitle { get; set; } = string.Empty;
    public string PostBody { get; set; } = string.Empty;
    public string PostSummary { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public Guid UserId { get; set; }

  }
}

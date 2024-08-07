using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKBlogSolution.Model.ViewModels.Comment
{
  public class CreateCommentRequest
  {
    public Guid UserId { get; set; }
    public int PostId { get; set; }

    public string Content { get; set; } = string.Empty;

  }
}

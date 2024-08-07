using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKBlogSolution.Model.ViewModels.Comment
{
  public class CreateSubCommentRequest
  {
    public int ParentCommentId { get; set; }
    public string Content { get; set; } = string.Empty;
    public Guid UserId { get; set; }

  }
}

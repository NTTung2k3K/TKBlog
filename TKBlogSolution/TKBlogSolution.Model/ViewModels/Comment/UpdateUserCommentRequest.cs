using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKBlogSolution.Model.ViewModels.Comment
{
  public class UpdateUserCommentRequest
  {
    public int CommentId { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; } = string.Empty;
  }
}

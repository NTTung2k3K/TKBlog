using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKBlogSolution.Model.ViewModels.Comment
{
  public class UpdateCommentRequest
  {
    public int CommentId { get; set; }
    public int StatusId { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Model.ViewModels.Post;
using TKBlogSolution.Model.ViewModels.User;

namespace TKBlogSolution.Model.ViewModels.Comment
{
  public class CommentVm
  {
    public int CommentId { get; set; }
    public string Content { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }

    public UserVm User { get; set; } = new UserVm();
    public CommentVm? ResponseComment { get; set; }

    public ICollection<CommentVm> ResponseComments { get; set; } = new HashSet<CommentVm>();
    public PostVm Post { get; set; } = new PostVm();


  }
}

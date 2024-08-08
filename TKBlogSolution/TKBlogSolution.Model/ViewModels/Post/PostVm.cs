using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Model.ViewModels.Category;
using TKBlogSolution.Model.ViewModels.Comment;
using TKBlogSolution.Model.ViewModels.Tag;
using TKBlogSolution.Model.ViewModels.User;

namespace TKBlogSolution.Model.ViewModels.Post
{
  public class PostVm
  {
    public int PostId { get; set; }
    public string PostTitle { get; set; } = string.Empty;
    public string PostBody { get; set; } = string.Empty;
    public string PostSummary { get; set; } = string.Empty;
    public int ViewCount { get; set; }
    public string Status { get; set; } = string.Empty;
    public string ThumbnailImage { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public CategoryVm Category { get; set; } = new CategoryVm();
    public ICollection<TagVm> PostTags { get; set; } = new List<TagVm>();
    public UserVm User { get; set; } = new UserVm();
    public ICollection<CommentVm> Comments { get; set; } = new List<CommentVm>();

  }
}

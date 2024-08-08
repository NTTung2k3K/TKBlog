using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKBlogSolution.Model.ViewModels.Tag
{
  public class UpdateTagRequest
  {
    public int TagId { get; set; }
    public string TagName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
  }
}

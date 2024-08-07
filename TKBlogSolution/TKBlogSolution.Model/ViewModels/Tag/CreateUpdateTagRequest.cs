using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKBlogSolution.Model.ViewModels.Category
{
  public class CreateUpdateTagRequest
  {
    public string TagName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

  }
}

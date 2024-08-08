using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKBlogSolution.Model.ViewModels.Role
{
  public class CreateRoleRequest
  {
    public string RoleName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
  }
}
